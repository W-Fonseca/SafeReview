
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SafeReview.Objetos_Blue_Prism
{
    class Leitura_blue_prism_process
    {
        //static void Leitura_objetos(Criar_Workbooks excel)
        public static void Leitor_Release(string Local_Release)
        {
            int numero_linha_excel = 1;
            string process_name = "";

            vExcelv.Criar_Workbooks excel = new vExcelv.Criar_Workbooks();
            excel.Criar_Workbook();
            excel.Criar_Woksheet("Conferencia_Processo");
            excel.criar_cabecalho_Processo();

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
                    Console.WriteLine("process Name: " + process_name);

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
                            // criar lista de duas colunas.


                            Console.WriteLine(tag.InnerText);

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


                            foreach (XmlNode exception in exceptions)
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
            leitura_blue_prism_object.Leitura_objetos(Local_Release, excel);
        }
    }
}
