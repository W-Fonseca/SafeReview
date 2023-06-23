
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Code_Inspector;
using Microsoft.Office.Interop.Excel;

namespace SafeReview.Objetos_Blue_Prism
{
    public class Leitura_blue_prism_process
    {
        public int numero_linha_excel = 1;
        public string process_name = "";

        //static void Leitura_objetos(Criar_Workbooks excel)
        public static void Leitor_Release(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            //---- não funcionando direito ----- programa.Padrao_leitura(Local_Release, excel);
            Leitura_blue_prism_process programa = new Leitura_blue_prism_process();
            excel.Excel_Visible();
            /*
            programa.conferencia_paginas_comuns(Local_Release, excel);
            programa.Tamanho_blocos(Local_Release, excel);
            programa.NomeProcessPadrao(Local_Release, excel);
            programa.OrderPages(Local_Release, excel);
            programa.Color_Block_MainPage(Local_Release, excel);
            programa.Contais_Kill_or_Close(Local_Release, excel);
            programa.Check_Stop_Mainpage(Local_Release, excel);
            programa.CheckPasswords(Local_Release, excel);
            programa.precondition_postcondition(Local_Release, excel);
            programa.ContStageInPage(Local_Release, excel);
            programa.E_mail_in_End_Process(Local_Release, excel);
            programa.check_dataItem(Local_Release, excel);
            programa.Check_Exceptions(Local_Release, excel);
            programa.work_queue(Local_Release, excel);
            programa.CheckAllHardCodeProcess(Local_Release, excel);
            programa.Check_Global_Itens(Local_Release, excel);
            */
            leitura_blue_prism_object.Leitura_objetos(Local_Release, excel);
            
        }
        public void conferencia_paginas_comuns(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             check se contem paginas: 
                mark completed
                mark exception
                reset data
                populate queue
                mail
                close down
            -------------------------------
                ação de recover
                resume
                se todos os exceptions são System exception ou Business exception.
            -------------------------------
                se existem paginas sem descrição.
                main page sem recovery 
                main page sem resume após recovery
             * 
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList contentsNodes = doc.SelectNodes("//*[@count]", ns);

            Console.WriteLine(contentsNodes.Count);
            Console.WriteLine(contentsNodes);

            Dictionary<string, string> nomes_paginas = new Dictionary<string, string>();

            foreach (XmlNode processNode in contentsNodes) //cada elemento
            {
                XmlNodeList process = processNode.SelectNodes("./ns:process/ns:process", ns);
                foreach (XmlNode pro in process) //cada objeto
                {
                    process_name = pro.Attributes["name"].Value;

                    if (pro.Attributes["narrative"].Value == "")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem descrição");
                    }

                    bool Check_CloseDown = false;
                    bool Check_SendMail = false;
                    bool Check_Exception = false;
                    bool Check_PrepareEnvironment = false;
                    bool Check_MarkCompleted = false;
                    bool Check_MarkException = false;
                    bool Check_ResetData = false;
                    bool Check_PopulateQueue = false;
                    bool Check_EndProcess = false;

                    /*
                     * Checagem se o processo contem paginas com nomes, Close Down, Mail, Mark Exception, etc.
                     */

                    XmlNodeList Subsheets = pro.SelectNodes("./ns:subsheet", ns);
                    foreach (XmlNode Subsheet in Subsheets) //cada objeto
                    {

                        XmlNodeList tags = Subsheet.SelectNodes("./ns:name", ns);

                        foreach (XmlNode tag in tags) //cada objeto
                        {
                            nomes_paginas.Add(Subsheet.Attributes["subsheetid"].Value, tag.InnerText);
                            if (tag.InnerText.Contains("Close Down", StringComparison.OrdinalIgnoreCase) && Check_CloseDown == false)
                            {
                                Check_CloseDown = true;
                            }

                            if (tag.InnerText.Contains("Mail", StringComparison.OrdinalIgnoreCase) && Check_SendMail == false)
                            {
                                Check_SendMail = true;
                            }

                            if (tag.InnerText.Contains("End Process", StringComparison.OrdinalIgnoreCase) && Check_CloseDown == false)
                            {
                                Check_EndProcess = true;
                            }

                            if (tag.InnerText.Contains("Exception", StringComparison.OrdinalIgnoreCase) && Check_Exception == false)
                            {
                                Check_Exception = true;
                            }

                            if (tag.InnerText.Contains("Prepare Environment", StringComparison.OrdinalIgnoreCase) && Check_PrepareEnvironment == false)
                            {
                                Check_PrepareEnvironment = true;
                            }

                            if (tag.InnerText.Contains("Mark", StringComparison.OrdinalIgnoreCase) && tag.InnerText.Contains("Completed", StringComparison.OrdinalIgnoreCase) && Check_MarkCompleted == false)
                            {
                                Check_MarkCompleted = true;
                            }

                            if (tag.InnerText.Contains("Mark", StringComparison.OrdinalIgnoreCase) && tag.InnerText.Contains("Exception", StringComparison.OrdinalIgnoreCase) && Check_MarkException == false)
                            {
                                Check_MarkException = true;
                            }

                            if (tag.InnerText.Contains("Reset", StringComparison.OrdinalIgnoreCase) && tag.InnerText.Contains("Data", StringComparison.OrdinalIgnoreCase) && Check_ResetData == false)
                            {
                                Check_ResetData = true;
                            }

                            if (tag.InnerText.Contains("Populate", StringComparison.OrdinalIgnoreCase) && tag.InnerText.Contains("Queue", StringComparison.OrdinalIgnoreCase) && Check_PopulateQueue == false)
                            {
                                Check_PopulateQueue = true;
                            }
                        }
                    }

                    if (Check_EndProcess == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem End Process");
                    }

                    if (Check_CloseDown == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Close Down");
                    }
                    if (Check_SendMail == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Send Mail");

                    }
                    if (Check_Exception == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Exception");
                    }
                    if (Check_PrepareEnvironment == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Prepare Environment");

                    }
                    if (Check_MarkCompleted == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Mark Completed");
                    }
                    if (Check_MarkException == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Mark Exception");
                    }
                    if (Check_ResetData == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Reset Global Data");
                    }

                    if (Check_PopulateQueue == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Populate Queue");
                    }

                    bool Check_Recover = false;
                    bool Check_Resume = false;

                    /*
                     * Checagem se a Main Page contem Recover, Resume, Exception, o tipo de exception, Etc.
                     */
                    XmlNodeList Stages = pro.SelectNodes("./ns:stage", ns);
                    foreach (XmlNode stage in Stages)
                    {
                        Console.WriteLine("type: " + stage.Attributes["type"].Value + " name: " + stage.Attributes["name"].Value);

                        if (stage.Attributes["type"].Value == "Recover" && Check_Recover == false)
                        {
                            Check_Recover = true;
                        }

                        if (stage.Attributes["type"].Value == "Resume" && Check_Resume == false)
                        {
                            Check_Resume = true;
                        }

                        if (stage.Attributes["type"].Value == "Exception" && stage.Attributes["name"].Value != "TERMINATE")
                        {
                            bool Check_Exceptions = false;
                            //string nome_da_pagina = "";

                            XmlNodeList exceptions = stage.SelectNodes("./ns:exception", ns);

                            /*
                             * valida se é diferente de "system exception ou "Business Exception"
                             */


                            foreach (XmlNode exception in exceptions)
                            {
                                XmlAttribute useCurrentAttr = exception.Attributes["usecurrent"];
                                if (useCurrentAttr != null)
                                {
                                    if (exception.Attributes["type"].Value != "System Exception" && exception.Attributes["type"].Value != "Business Exception" && exception.Attributes["usecurrent"].Value != "yes")
                                    {
                                        numero_linha_excel += 1;
                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                                        XmlNode nome_da_página = stage.SelectSingleNode("./ns:subsheetid", ns);
                                        Console.WriteLine(nome_da_página.InnerText);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", nomes_paginas[nome_da_página.InnerText]); //arrumar aqui, preciso saber o nome da página.
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception: " + stage.Attributes["name"].Value + " com marcação diferente de 'System Exception' ou 'Business Exception'");
                                    }
                                }
                                else
                                {
                                    if (exception.Attributes["type"].Value != "System Exception" && exception.Attributes["type"].Value != "Business Exception")
                                    {
                                        numero_linha_excel += 1;
                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                                        XmlNode nome_da_página = stage.SelectSingleNode("./ns:subsheetid", ns);
                                        Console.WriteLine(nome_da_página.InnerText);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", nomes_paginas[nome_da_página.InnerText]); //arrumar aqui, preciso saber o nome da página.
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception: " + stage.Attributes["name"].Value + " com marcação diferente de 'System Exception' ou 'Business Exception'");
                                    }
                                }
                            }
                        }

                        if (stage.Attributes["type"].Value == "SubSheetInfo")
                        {
                            bool narrativa = false;
                            XmlNodeList Narrativas = stage.SelectNodes("./ns:narrative", ns);
                            foreach (XmlNode Narrativa in Narrativas)
                            {
                                narrativa = true;
                            }

                            if (narrativa == false)
                            {
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", stage.Attributes["name"].Value);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Stagio sem descrição");
                            }
                        }
                    }
                    if (Check_Recover == false)
                    {

                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Recovery");
                    }

                    if (Check_Resume == false)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Main page sem Resume após recovery");
                    }
                }
            }
        }

        public void precondition_postcondition(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * O campo pós-condições de cada página está preenchido com o(s) resultado(s) obtido(s) após a sua execução
             * O campo pré-condições de cada página está preenchido com os requisitos iniciais relevantes para a sua execução
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);
            foreach (XmlNode stage in ListNodes)
            {
                bool preconditions = false;
                bool postconditions = false;
                if (stage.Attributes["type"].Value == "Start")
                {
                    try
                    {
                        //if stage.SelectSingleNode("./ns:subsheetid")
                        if (stage.SelectSingleNode("./ns:preconditions/ns:condition/@narrative", ns).Value != "")
                        {
                            preconditions = true;

                        }
                    }
                    catch { }
                    try
                    {
                        if (stage.SelectSingleNode("./ns:postconditions/ns:condition/@narrative", ns).Value != "")
                        {
                            postconditions = true;

                        }

                    }
                    catch { }

                    try
                    {
                        if (preconditions == false)
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição preconditions na página");
                        }

                        if (postconditions == false)
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição postconditions na página");
                        }
                    }
                    catch { }

                }
            }

        }

        public void Padrao_leitura(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
            O código desenvolvido deve seguir o padrão de leitura 
            (de cima para baixo | alinhamento entre o start e o end | da esquerda para direita) 
            */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList contentsNodes = doc.SelectNodes("//*[@count]", ns);

            foreach (XmlNode processNode in contentsNodes) //cada elemento
            {

                XmlNodeList process = processNode.SelectNodes("./ns:process/ns:process/ns:stage", ns);
                foreach (XmlNode pro in process) //cada objeto
                {
                    XmlNodeList stageNodes = pro.SelectNodes("./ns:stage", ns);


                    bool isOrdered = true;
                    string current_Stage_Name = "";
                    string next_Stage_Name = "";
                    for (int i = 0; i < stageNodes.Count - 1; i++)
                    {
                        XmlNode currentNode = stageNodes[i];
                        XmlNode nextNode = stageNodes[i + 1];

                        current_Stage_Name = currentNode.Attributes["name"].Value;
                        next_Stage_Name = nextNode.Attributes["name"].Value;
                        int currentX = int.Parse(currentNode.SelectSingleNode("./ns:display/@x", ns).Value);
                        int currentY = int.Parse(currentNode.SelectSingleNode("./ns:display/@y", ns).Value);
                        int nextX = int.Parse(nextNode.SelectSingleNode("./ns:display/@x", ns).Value);
                        int nextY = int.Parse(nextNode.SelectSingleNode("./ns:display/@y", ns).Value);

                        // Verifique se o próximo estágio está abaixo ou à direita do estágio atual
                        if (nextY < currentY || nextX < currentX)
                        {
                            isOrdered = false;
                            break;
                        }
                    }
                    if (isOrdered)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Stagio: " + current_Stage_Name + " é diferente ao estágio: " + next_Stage_Name);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Os estágios estão seguindo de cima para baixo e da esquerda para a direita.");
                        Console.WriteLine("Os estágios estão seguindo de cima para baixo e da esquerda para a direita.");
                    }
                    else
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Stagio: " + current_Stage_Name + " é diferente ao estágio: " + next_Stage_Name);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Os estágios não estão seguindo a ordem desejada (cima para baixo e da esquerda para a direita).");
                    }
                }
            }
        }
        public void Tamanho_blocos(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Itens/Collections devem ter 2 blocos de altura e 8 blocos de largura. 
             * Os stages devem ter de 2 blocos de altura e 6/8 blocos de largura. 
             * As Pages devem ter 4 blocos de comprimento e 6/8 blocos de largura.
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList contentsNodes = doc.SelectNodes("//*[@count]", ns);

            foreach (XmlNode processNode in contentsNodes) //cada elemento
            {

                XmlNodeList process = processNode.SelectNodes("./ns:process/ns:process/ns:stage", ns);
                foreach (XmlNode stage in process) //cada objeto
                {
                    if (stage.Attributes["type"].Value == "Data" || stage.Attributes["type"].Value == "Collection")
                    {
                        string nomeStage = stage.Attributes["name"].Value;
                        int currentw = int.Parse(stage.SelectSingleNode("./ns:display/@w", ns).Value);
                        int currenth = int.Parse(stage.SelectSingleNode("./ns:display/@h", ns).Value);

                        if (currentw != 90 && currenth != 60)
                        {
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", process_name);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Data Item: " + nomeStage);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "Itens/Collections devem ter 2 blocos de altura e 8 blocos de largura.");
                        }
                    }
                }
            }
        }
        public void NomeProcessPadrao(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Os nomes dos processo segue as melhores práticas de BP ou a convenção de nomenclatura local: 
                Pasta: [ID Processo] - [Nome Processo]
                Process: [ID Processo] - [Nome Processo/Etapa Processo]
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            string name = doc.SelectSingleNode(".//ns:process/@name", ns).Value;

            Regex regex = new Regex("^P\\d{3}");
            Match match = regex.Match(name.ToString());
            if (match.Success == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", name);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Name Process");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Nome do Processo não começa com P(processo) + numero do processo (deve conter 3 digitos).");
            }
            regex = new Regex("_\\d{3}_");
            match = regex.Match(name);
            if (match.Success == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", name);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Name Process");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Nome do Processo não especifica a UC (use case) Ex: P189_UC_NomeDoProcesso (deve conter 3 digitos).");
            }
            int primeiroUnderscore = name.IndexOf('_');
            int segundoUnderscore = name.IndexOf('_', primeiroUnderscore + 1);
            string novonome = name.Substring(segundoUnderscore);
            regex = new Regex("_(\\w+)");
            match = regex.Match(novonome);
            if (match.Success == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", name);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Name Process");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Não foi encontrado o nome do processo exemplo P189_UC_NomeDoProcesso");
            }
        }
        public void OrderPages(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * 
             * A ordenação das"Abas" das páginas está na sequência de execução das mesmas
             */
            List<Tuple<string, int>> NomesPorID = new List<Tuple<string, int>>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNode IDNode = doc.SelectSingleNode(".//ns:process/ns:process/ns:stage/ns:onsuccess", ns);
            string IDProcurado = IDNode.InnerText;
            int contagem = 0;

            XmlNodeList TodoXML = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);
            bool existeID = true;
            while (existeID == true)
            {
                foreach (XmlNode Stage in TodoXML)
                {
                    if (Stage.Attributes["stageid"].Value == IDProcurado)
                    {
                        try
                        {

                            IDProcurado = Stage.SelectSingleNode("./ns:onsuccess", ns).InnerText;

                        }
                        catch
                        {
                            try
                            {
                                IDProcurado = Stage.SelectSingleNode("./ns:ontrue", ns).InnerText;
                            }
                            catch
                            {
                                existeID = false;
                            }
                        }

                        //numero_linha_excel += 1;
                        contagem += 1;

                        if (Stage.Attributes["type"].Value == "SubSheet")
                        {
                            NomesPorID.Add(new Tuple<string, int>(Stage.Attributes["name"].Value, contagem));
                        }


                    }
                }
            }

            // XmlNode StagesName = doc.SelectSingleNode(".//ns:process/ns:process/ns:stage/ns:subsheet/ns:name", ns);
            XmlNodeList StagesName = doc.SelectNodes(".//ns:process/ns:process/ns:subsheet/ns:name", ns);

            foreach (var item in NomesPorID)
            {
                foreach (XmlNode Stage in StagesName)
                {
                    if (Stage.InnerText != item.Item1)
                    {
                        string OrdemCorreta = "";
                        foreach (var items in NomesPorID)
                        {
                            OrdemCorreta = OrdemCorreta + ", " + items.Item1.ToString();
                        }
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Ordem das Páginas com Ordem de execução diferente, Ordem corretá [" + OrdemCorreta + "] depois vir as demais páginas.");
                        existeID = true;
                        break;

                    }

                    // começa aqui

                }
                if (existeID == true)
                {
                    break;
                }

            }
        }
        public void Color_Block_MainPage(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * O bloco 'Input' tem a cor de fundo #0000FF
                O bloco 'Local' tem a cor de fundo #008000
                O bloco 'Output' tem a cor de fundo #00CCFF
                O bloco 'Process Settings'  tem a cor de fundo #00CCFF
                O bloco 'Stopping Control Settings' tem a cor de fundo #FF0000
                Os blocos que incluem 'Environment' tem a cor de fundo #FFC000
                Os blocos que incluem 'Global' tem a cor de fundo #ED7D31
                Os blocos que não são de nenhum outro tipo de bloco, têm a cor de fundo #00CCFF
             */
            bool processSetings = false;
            bool StoppingControlSettings = false;
            bool ExceptionControlSettings = false;
            bool Blockdiferente = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);
            foreach (XmlNode stage in ListNodes) //cada objeto
            {
                Blockdiferente = false;
                if (stage.Attributes["name"].Value == "Process Settings" && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "00CCFF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco 'Process Settings' deve ser 00CCFF");
                        processSetings = true;
                    }
                    Blockdiferente = true;
                }

                if (stage.Attributes["name"].Value == "Stopping Control Settings" && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "FF0000")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco 'Stopping Control Settings' deve ser 'FF0000'");
                        StoppingControlSettings = true;
                    }
                    Blockdiferente = true;
                }
                if (stage.Attributes["name"].Value == "Exception Control Settings" && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "FF0000")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco 'Exception Control Settings' deve ser 'FF0000'");
                        ExceptionControlSettings = true;
                    }
                    Blockdiferente = true;
                }

                if (stage.Attributes["name"].Value.Contains("Global", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "ED7D31")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        try
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            excel.Escreva_Worksheet(numero_linha_excel, "C", doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText);
                        }
                        catch
                        {
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        }
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " = 'Bloco Global' deve ser 'ED7D31'");
                        Blockdiferente = true;
                    }
                }
                if (stage.Attributes["name"].Value.Contains("Environment", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "FFC000")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page" + stage.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " = 'Environment' deve ser 'FFC000'");
                    }
                    Blockdiferente = true;
                }

                if (stage.Attributes["name"].Value.Contains("Input", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "0000FF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        try
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            excel.Escreva_Worksheet(numero_linha_excel, "C", doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText);
                        }
                        catch
                        {
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        }
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " = 'Input' deve ser '0000FF'");
                        Blockdiferente = true;
                    }
                }

                if (stage.Attributes["name"].Value.Contains("Local", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {

                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "008000")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);

                        try
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            excel.Escreva_Worksheet(numero_linha_excel, "C", doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText);
                        }
                        catch
                        {
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        }
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " = 'Local' deve ser '008000'");
                        Blockdiferente = true;
                    }
                }

                if (stage.Attributes["name"].Value.Contains("Output", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "00CCFF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        try
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            excel.Escreva_Worksheet(numero_linha_excel, "C", doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText);
                        }
                        catch
                        {
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        }
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " = 'Output' deve ser '00CCFF'");
                        Blockdiferente = true;
                    }
                }
                if (Blockdiferente == false && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "00CCFF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);

                        try
                        {
                            string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                            excel.Escreva_Worksheet(numero_linha_excel, "C", doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText);
                        }
                        catch
                        {
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                        }
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Cor do bloco " + stage.Attributes["name"].Value + " deve ser '00CCFF'");
                    }
                }
            }
            if (processSetings == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Processo fora do padrão, não contem bloco 'Process Settings'");

            }
            if (StoppingControlSettings == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Processo fora do padrão, não contem bloco 'Stopping Control Settings'");

            }

            if (ExceptionControlSettings == false)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Processo fora do padrão, não contem bloco 'ExceptionControlSettings'");

            }
        }
        public void Contais_Kill_or_Close(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * A página End Process e/ou a Close Down possuem Kill e/ou Close Instances para encerrar todas as aplicações utilizadas durante o processamento
             */
            bool check_closedown_EndProcess = false;
            bool check_EndProcess = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);

            foreach (XmlNode stage in ListNodes)
            {
                try
                {
                    if (stage.SelectSingleNode("./ns:resource/@action", ns).Value == "Kill Process")
                    {
                        string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                        string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                        if (nome_Pagina.Contains("Close Down", StringComparison.OrdinalIgnoreCase) || nome_Pagina.Contains("End Process", StringComparison.OrdinalIgnoreCase))
                        {
                            check_closedown_EndProcess = true;
                            break;
                        }
                    }
                }
                catch { }
            }
            if (check_closedown_EndProcess == true)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Processo não contem Kill process em pagina Close Down ou End Process'");
            }
        }
        public void Check_Stop_Mainpage(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            bool encontrado = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);

            foreach (XmlNode stage in ListNodes)
            {
                string subsheetid = null;

                if (stage.Attributes["name"].Value.Contains("Stop", StringComparison.OrdinalIgnoreCase) && stage.Attributes["name"].Value != null)
                {
                    try
                    {
                        subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    }
                    catch { }

                    if (subsheetid == null)
                    {
                        encontrado = true;
                        break;
                    }
                }

            }
            if (encontrado != true)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Processo não contem Stop entre execução de cada item'");
            }
        }
        public void E_mail_in_End_Process(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            // não terminado
            bool encontrado = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);
            string subsheetid = null;
            foreach (XmlNode stage in ListNodes)
            {
                if (stage.SelectSingleNode("./ns:resource/@object", ns) != null && stage.SelectSingleNode("./ns:resource/@object", ns).Value == "Email - POP3/SMTP" && stage.SelectSingleNode("./ns:resource/@action", ns).Value == "Send Message")
                {
                    subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                    if (nome_Pagina.Contains("end", StringComparison.OrdinalIgnoreCase) || nome_Pagina.Contains("close", StringComparison.OrdinalIgnoreCase))
                    {

                    }
                    else
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Pagina contem send email mas não é uma página de close ou end process'");
                    }
                }

            }
            if (subsheetid == null)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Não foi encontrado nenhum send email utilizando 'Email - POP3/SMTP' no processo.");
            }


        }
        public void CheckPasswords(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            //Não há nenhuma senha codificada no diagrama/item data
            //resource object="Blueprism.Automate.clsCredentialsActions" action="Get"
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage/ns:resource[@object='Blueprism.Automate.clsCredentialsActions']", ns);
            string NomedoStagio = null;
            foreach (XmlNode xnode in ListNodes)
            {
                XmlNode stage = xnode.ParentNode;
                try
                {
                    //if (stage.SelectSingleNode(".//ns:resource/@object", ns).Value == "Blueprism.Automate.clsCredentialsActions" && stage.SelectSingleNode(".//ns:resource/@action", ns).Value == "Get")
                    if (stage.SelectSingleNode(".//ns:resource/@action", ns).Value == "Get")
                    {

                        string nomedostagioconferencia = stage.Attributes["name"].Value;
                        XmlNodeList outputs = stage.SelectNodes("./ns:outputs/ns:output", ns);
                        foreach (XmlNode output in outputs)
                        {
                            // try
                            // {
                            if (output.Attributes["type"].Value != null && output.Attributes["type"].Value == "password")
                            {
                                NomedoStagio = output.Attributes["stage"].Value;
                                break;
                            }
                            // }
                            // catch { }
                        }

                        string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                        string nomeStagio_output = stage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                        string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                        //if (doc.SelectSingleNode(".//ns:process/ns:process/ns:stage[@name='" + NomedoStagio + "']", ns).SelectSingleNode("./ns:subsheetid", ns).InnerText == subsheetid)
                        XmlNodeList ListNodes2 = doc.SelectNodes(".//ns:process/ns:process/ns:stage[@name='" + NomedoStagio + "']", ns);
                        foreach (XmlNode stage2 in ListNodes2)
                        {
                            //XmlNode stage2 = xnode2.ParentNode;
                            try
                            {
                                nomedostagioconferencia = stage2.Attributes["name"].Value;
                                if (stage2.SelectSingleNode("./ns:subsheetid", ns).InnerText == subsheetid && stage2.Attributes["name"].Value == NomedoStagio)
                                {
                                    nomedostagioconferencia = stage2.Attributes["name"].Value;
                                    if (stage2.SelectSingleNode("./ns:datatype", ns).InnerText != "password")
                                    {
                                        numero_linha_excel += 1;
                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "O estágio " + stage2.Attributes["name"].Value + " recebe um password e não está codificado.'");
                                    }
                                    break;
                                }
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }

        }
        public void ContStageInPage(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * As páginas e sub páginas são simples, curtas e de fácil manutenção
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:subsheet", ns);
            foreach (XmlNode subsheet in ListNodes)
            {

                int contagem_itens_in_page = 0;
                string NomePagina = subsheet.SelectSingleNode("./ns:name", ns).InnerText;

                XmlNodeList ListNodes2 = doc.SelectNodes(".//ns:process/ns:process/ns:stage", ns);

                foreach (XmlNode stage in ListNodes2)
                {

                    if (stage.SelectSingleNode("./ns:subsheetid", ns) != null && stage.SelectSingleNode("./ns:subsheetid", ns).InnerText == subsheet.Attributes["subsheetid"].Value)
                    {
                        if (stage.Attributes["type"].Value != "Block" && stage.Attributes["type"].Value != "Collection" && stage.Attributes["type"].Value != "Data" && stage.Attributes["type"].Value != "Anchor")
                        {
                            contagem_itens_in_page++;
                        }
                    }

                    //string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                }
                if (contagem_itens_in_page > 36)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", NomePagina);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "A página contem " + contagem_itens_in_page + " O permitido é até 35 ações");
                }
            }
        }
        public void check_dataItem(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Check data Item if contains initial value.
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage/ns:initialvalue", ns);
            string nome_pagina = null;
            foreach (XmlNode stages in ListNodes)
            {
                if (stages.InnerText != "")
                {
                    XmlNode stage = stages.ParentNode;

                    if (stage.Attributes["type"].Value == "Data" || stage.Attributes["type"].Value == "Collection")
                    {
                        if (stage.SelectSingleNode("./ns:subsheetid", ns) != null)
                        {
                            nome_pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + stage.SelectSingleNode("./ns:subsheetid", ns).InnerText + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", nome_pagina);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "O data Item / Collection :'" + stage.Attributes["name"].Value + "' contem o valor inicial pré estabelecido");
                        }
                        else
                        {
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "O data Item / Collection :'" + stage.Attributes["name"].Value + "' contem o valor inicial pré estabelecido");
                        }
                    }
                }
            }
        }
        public void Check_Exceptions(string Local_Release, vExcelv.Criar_Workbooks excel)
        {

            /*
             * O tipo da exceção está preenchido e foi selecionado entre os já existentes
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:process/ns:process/ns:stage[@type='Exception']", ns);

            Dictionary<string, string> ExceptionDetails = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string nome_Pagina;

            foreach (XmlNode Node in ListNodes)
            {
                string nome_stage = Node.Attributes["name"].Value;
                if (Node.Attributes["name"].Value != "TERMINATE")
                {
                    if(Node.SelectSingleNode("./ns:exception/@usecurrent", ns) == null) 
                    {               
                        if (Node.SelectSingleNode("./ns:exception/@type",ns).Value != "System Exception" && Node.SelectSingleNode("./ns:exception/@type",ns).Value != "Business Exception")
                        {
                            if (Node.SelectSingleNode("./ns:subsheetid", ns).InnerText != null)
                            {
                                string subsheetid = Node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                                nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");                        
                                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);                      
                                excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception: '" + Node.Attributes["name"].Value + "' não é 'System Exception' ou 'Business Exception' ou está preservado.");
                            }
                            else
                            {
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Main Page");                        
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception: '" + Node.Attributes["name"].Value + "' não é 'System Exception' ou 'Business Exception' ou está preservado.");                    
                            }                
                        }
                    }
                }
                if (Node.SelectSingleNode("./ns:exception/@detail", ns).Value != null && Node.SelectSingleNode("./ns:exception/@type", ns).Value != null && Node.Attributes["name"].Value != "TERMINATE" && Node.SelectSingleNode("./ns:exception/@usecurrent", ns) == null)
                {

                    /*
                     * As exceções possuem "Name" e "Type" iguais
                     * O texto do campo Exception Detail não se repete para mais de uma Exception do Processo
                     */

                    nome_Pagina = null;
                    try { 
                    string subsheetid = Node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                    }
                    catch { nome_Pagina = "Main Page"; }
                    if (ExceptionDetails.ContainsKey(nome_stage +" - "+ Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value))
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Na pagina '" + nome_Pagina + "' Foi encontrado o Exception ["+ nome_stage+ "] igual dá " + ExceptionDetails[nome_stage + " - " + Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value]);
                    }
                    else
                    {
                        ExceptionDetails.Add(nome_stage +" - "+Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value,"Pagina: ["+nome_Pagina+"] Exception Name: ["+ nome_stage +"]");
                    }
                }
            }
        }
        public void work_queue(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * O nome da Work Queue está igual ao nome do seu respectivo processo
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/work-queue");
            XmlNodeList NodeWorkQueue_Name = doc.SelectNodes(".//ns:work-queue/@name", ns);
            try
            {
                ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
                XmlNode NodeProcess_Name = doc.SelectSingleNode(".//ns:process/ns:process/@name", ns);

                foreach (XmlNode NomeQueue in NodeWorkQueue_Name)
                {
                    double similaridade = CalcularSimilaridade(NodeProcess_Name.Value, NomeQueue.Value);
                    if (similaridade <= 0.80)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Work Queue");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Nome do processo ( " + NodeProcess_Name.Value + " ) e Work Queue ( " + NomeQueue.Value + " ) são diferentes!");
                    }
                }
            }
            catch 
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Work Queue");
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Não foi possivel identificar um work queue na release");
            }
            static double CalcularSimilaridade(string str1, string str2)
            {
                // chat GPT
                // Converte as strings em conjuntos de caracteres (usando Distinct para remover caracteres duplicados)
                var conjunto1 = str1.ToCharArray().Distinct();
                var conjunto2 = str2.ToCharArray().Distinct();

                // Calcula a interseção entre os conjuntos
                var intersecao = conjunto1.Intersect(conjunto2);

                // Calcula a união dos conjuntos
                var uniao = conjunto1.Union(conjunto2);

                // Calcula o coeficiente de Jaccard
                double coeficienteJaccard = (double)intersecao.Count() / uniao.Count();

                return coeficienteJaccard;
            }
        }

        public void CheckAllHardCodeProcess(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Nenhum Data Item/Collection/Stage contém informações codificada diretamente neles que poderiam mudar com o tempo/circunstâncias 
            */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodesA = doc.SelectNodes(".//ns:process/ns:process/ns:stage//@expr", ns);
            XmlNodeList ListNodesB = doc.SelectNodes(".//ns:process/ns:process/ns:stage//@expression", ns);
            CheckStage(ListNodesA, excel);
            numero_linha_excel += 1;
            CheckStage(ListNodesB, excel);

            void CheckStage(XmlNodeList ListNodes, vExcelv.Criar_Workbooks excel)
            {
                foreach (XmlNode stage in ListNodes)
                {

                    Regex regex1 = new Regex(@"\[[^\]]*\]"); // sem '[' e ']'
                    Regex regex2 = new Regex(@"\([^)]*\)"); // sem '(' e ')' 
                    string expression = stage.Value;

                    Match match1 = regex1.Match(stage.Value);
                    Match match2 = regex2.Match(stage.Value);
                    if (match1.Success == false && match2.Success == false)
                    {
                        //     int index = match.Index;
                        //    if ((index > 0 && stage.Value[index - 1] != ' ') || (index + match.Length < stage.Value.Length && stage.Value[index + match.Length] != ' ')) //encontra se existe algum valor antes e depois de [] de timeout waitstart
                        //    {
                        if (expression != "" && expression != "Business Exception" && expression != "System Exception" && expression != "True" && expression != "False")
                        {
                            string nome_Pagina;
                            XmlNode ParentStage = stage;

                            while (ParentStage != null && ParentStage.Name != "stage")
                            {
                                ParentStage = ParentStage.SelectSingleNode("..");
                            }

                            if (ParentStage.Attributes["type"].Value != "Calculation" && ParentStage.Attributes["type"].Value != "MultipleCalculation")
                            {
                                try
                                {
                                    string subsheetid = ParentStage.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                                    nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                                }
                                catch { nome_Pagina = "Main Page"; }
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "O item: " + ParentStage.Attributes["name"].Value + " Contem HardCode com a expressão: " + expression);
                            }
                        }
                    }
                }
            }
        }
        public void Check_Global_Itens(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Todas as variáveis Globais devem estar na página Main Page ou Initialize
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodesA = doc.SelectNodes(".//ns:process/ns:process/ns:stage[@type='Data']/ns:subsheetid", ns);
            XmlNodeList ListNodesB = doc.SelectNodes(".//ns:process/ns:process/ns:stage[@type='Collection']/ns:subsheetid", ns);
            CheckStage(ListNodesA, excel);
            CheckStage(ListNodesB, excel);

            void CheckStage(XmlNodeList ListNodes, vExcelv.Criar_Workbooks excel)
            {
                foreach (XmlNode stage in ListNodes)
                {
                    XmlNode node = stage.ParentNode;
                    if (node.SelectSingleNode("./ns:private", ns) == null)
                    {
                        string nomeStagio = node.Attributes["name"].Value;
                        string typeStagio = node.Attributes["type"].Value;
                        string subsheetid = node.SelectSingleNode("./ns:subsheetid",ns).InnerText;
                        string nome_Pagina = doc.SelectSingleNode(".//ns:process/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                        if (nome_Pagina != "Reset Global Data" && nome_Pagina != "Mark Item As Exception")
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:process/ns:process/@name", ns).Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "A "+ typeStagio + "( " + nomeStagio + " ) è Global e está na subpágina ( " + nome_Pagina + " ) em vez da Main Page");
                    }
                }
            }
        

        }
    }
}
