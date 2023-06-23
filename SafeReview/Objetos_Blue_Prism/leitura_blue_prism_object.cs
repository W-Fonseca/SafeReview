
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;

namespace SafeReview.Objetos_Blue_Prism
{
    class leitura_blue_prism_object
    {
        int numero_linha_excel = 1;

        public static void Leitura_objetos(string Local_Release, vExcelv.Criar_Workbooks excel) //encontra os elementos de cada objeto
        {

            leitura_blue_prism_object programa_objeto = new leitura_blue_prism_object();
            excel.Criar_Woksheet("Conferencia_Objetos");
            excel.criar_cabecalho_Objetos();
           /* programa_objeto.Check_elements_and_attibutes(Local_Release, excel);
            programa_objeto.Check_Publish(Local_Release, excel);
            programa_objeto.Count_Page(Local_Release, excel);
            programa_objeto.Check_wait_time(Local_Release, excel);
            programa_objeto.Check_All_Exception(Local_Release, excel);
            programa_objeto.Preconditions_PostConditions(Local_Release, excel);
            programa_objeto.Check_Narrative(Local_Release, excel);
            programa_objeto.Count_Stages_InPage(Local_Release, excel);
            programa_objeto.Check_Contais_Stage_InPage(Local_Release, excel);
           */
            programa_objeto.Tamanho_blocos(Local_Release, excel); 
        }
        public void Check_elements_and_attibutes(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            string nome_objeto = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList objectNodes = doc.SelectNodes(".//ns:object", ns);

            foreach (XmlNode objectNode in objectNodes) //cada objeto
            {

                nome_objeto = objectNode.Attributes["name"].Value;
                Console.WriteLine("Object Name: " + objectNode.Attributes["name"].Value);


                XmlNodeList elementNodes = objectNode.SelectNodes(".//ns:element", ns);
                foreach (XmlNode elementNode in elementNodes) //cada elemento
                {
                    if (elementNode.Attributes != null && elementNode.Attributes["name"] != null)
                    {

                        Console.WriteLine("Element Name: " + elementNode.Attributes["name"].Value);
                        Check_Nome_Elemento validador = new Check_Nome_Elemento();

                        if (validador.ValidarNome(elementNode.Attributes["name"].Value))
                        {
                            Console.WriteLine("existe");
                        }
                        else
                        {
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + elementNode.Attributes["name"].Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", "tipo de elemento com descrição errada ou sem hífens com espaçamento entre ele");
                        }

                        XmlNodeList Atributoss = elementNode.SelectNodes("./ns:attributes", ns);

                        foreach (XmlNode Atributo in Atributoss) //cada atributos
                        {

                            XmlNodeList Atributs = Atributo.SelectNodes("./ns:attribute", ns);

                            foreach (XmlNode Atribut in Atributs) //cada atributos
                            {
                                if (Atribut.Attributes != null && Atribut.Attributes["name"] != null)
                                {
                                    if (Atribut.Attributes["name"].Value == "ScreenVisible" && Atribut.Attributes["inuse"] != null) //erro encontrado, não pode ter screenVisible aplicado.
                                    {
                                        numero_linha_excel += 1;

                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + elementNode.Attributes["name"].Value);
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "ScreenVisible = True");
                                        //(ScreenVisible não pode estar marcado, pois cria uma dependencia da aplicação estar visivel mesmo estando minimizada)
                                    }

                                    else if (Atribut.Attributes["name"].Value == "Visible" && Atribut.Attributes["inuse"] != null) //erro encontrado, não pode ter Visible aplicado.
                                    {
                                        numero_linha_excel += 1;

                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + elementNode.Attributes["name"].Value);
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Visible = True");
                                        //(ScreenVisible não pode estar marcado, pois cria uma dependencia da aplicação estar visivel mesmo estando minimizada)
                                    }

                                    else
                                    {
                                        if (Atribut.Attributes["inuse"] != null)
                                        {

                                            XmlNodeList ProcessValues = Atribut.SelectNodes(".//ns:ProcessValue", ns);
                                            foreach (XmlNode ProcessValue in ProcessValues) //cada atributo
                                            {

                                                if (ProcessValue.Attributes["value"].Value != null)
                                                {
                                                    Console.WriteLine("Atributo Name: " + Atribut.Attributes["name"].Value + " Atributo Inuse: " + Atribut.Attributes["inuse"].Value + " Atributo Valor: " + ProcessValue.Attributes["value"].Value);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Atributo Name: " + Atribut.Attributes["name"].Value + " Atributo Inuse: " + Atribut.Attributes["inuse"].Value);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Atributo Name: " + Atribut.Attributes["name"].Value);
                                        }
                                    }
                                    if (Atribut.Attributes["name"].Value == "MatchIndex")
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Check_Publish(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns); //appdef linha 5
            foreach (XmlNode Node in Nodes)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                excel.Escreva_Worksheet(numero_linha_excel, "B", Node.SelectSingleNode("..").Attributes["name"].Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Node.SelectSingleNode("./ns:name", ns).InnerText);
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Published: " + Node.Attributes["published"].Value);
            }
        }

        public void Check_Contais_Stage_InPage(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Os objetos não tentam recuperar exceções (deve ser lógica de processo)
             * Os stages Wait expiram para uma System Exception
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns);

            foreach (XmlNode node in Nodes)
            {
                string objectid = node.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string Name_page = node.SelectSingleNode("./ns:name", ns).InnerText;
                string subsheetid = node.Attributes["subsheetid"].Value;
                XmlNode teste = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Exception'][ns:subsheetid='" + subsheetid + "']", ns);

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Exception'][ns:subsheetid='" + subsheetid + "']", ns) == null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "A página não contem exception");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='WaitStart'][ns:subsheetid='" + subsheetid + "']", ns) == null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "A página Não contem Wait");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Recover'][ns:subsheetid='" + subsheetid + "']", ns) != null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "A página contem Recover");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Resume'][ns:subsheetid='" + subsheetid + "']", ns) != null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "A página contem Resume");
                }


                // XmlNodeList Stages = doc.SelectNodes(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[ns:subsheetid='" + subsheetid + "']/@type='Exception'", ns);
            }
        }
        public void Count_Page(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns); //appdef linha 5

            string name_process = null;
            int count_page = 0;
            foreach (XmlNode Node in Nodes)
            {


                if (name_process == Node.SelectSingleNode("..").Attributes["name"].Value)
                {
                    count_page += 1;
                }

                else
                {
                    if (count_page > 15)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Alerta");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", Node.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Objeto");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Objeto com numero excessivo de páginas, o maximo é 15, quantidade criada é: " + count_page);
                    }
                    name_process = Node.SelectSingleNode("..").Attributes["name"].Value;
                    count_page = 1;
                }
            }
        }

        public void Count_Stages_InPage(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns);

            foreach (XmlNode node in Nodes)
            {
                string objectid = node.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string Name_page = node.SelectSingleNode("./ns:name", ns).InnerText;
                string subsheetid = node.Attributes["subsheetid"].Value;
                XmlNodeList Stages = doc.SelectNodes(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[ns:subsheetid='" + subsheetid + "']", ns);
                int contagem_stagios = 0;
                foreach (XmlNode stage in Stages)
                {
                    if (stage.Attributes["type"].Value != "SubSheetInfo" && stage.Attributes["type"].Value != "Note" && stage.Attributes["type"].Value != "Data" && stage.Attributes["type"].Value != "Collection" && stage.Attributes["type"].Value != "Block")
                    {
                        contagem_stagios++;
                        string name_stage = stage.Attributes["name"].Value;
                    }
                }
                if (contagem_stagios > 15)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Pagina contem um total de " + contagem_stagios + " estágios, o maximo permitido é 15");
                }
            }
        }

        public void Check_wait_time(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='WaitStart']/ns:timeout", ns);

            foreach (XmlNode timeout in Nodes)
            {
                Regex regex = new Regex(@"\[[^\]]*\]");

                Match match = regex.Match(timeout.InnerText);
                if (match.Success)
                {
                    int index = match.Index;
                    if ((index > 0 && timeout.InnerText[index - 1] != ' ') || (index + match.Length < timeout.InnerText.Length && timeout.InnerText[index + match.Length] != ' ')) //encontra se existe algum valor antes e depois de [] de timeout waitstart
                    {

                        string subsheetid = timeout.SelectSingleNode("..").SelectSingleNode("./ns:subsheetid", ns).InnerText;
                        string nome_Pagina = doc.SelectSingleNode(".//ns:object/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", timeout.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "timeout: " + timeout.SelectSingleNode("..").Attributes["name"].Value + " com valor fixo de: " + timeout.InnerText);
                    }
                }
                else
                {
                    string subsheetid = timeout.SelectSingleNode("..").SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    string nome_Pagina = doc.SelectSingleNode(".//ns:object/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", timeout.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + nome_Pagina);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "timeout: " + timeout.SelectSingleNode("..").Attributes["name"].Value + " com valor fixo de: " + timeout.InnerText);

                }
            }
        }
        public void Check_All_Exception(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='Exception']", ns);

            foreach (XmlNode node in Nodes)
            {
                XmlNode Exception = node.SelectSingleNode("./ns:exception", ns);

                if (Exception.Attributes["type"].Value != "System Exception" && Exception.Attributes["type"].Value != "Business Exception")
                {
                    string subsheetid = node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    string nome_Pagina = doc.SelectSingleNode(".//ns:object/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + nome_Pagina);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception com: " + Exception.Attributes["type"].Value + " o correto é: System Exception ou Business Exception");
                }
            }
        }
        public void Preconditions_PostConditions(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns);

            //subsheetid
            foreach (XmlNode node in Nodes)
            {
                string name_page = node.SelectSingleNode("./ns:name", ns).InnerText;
                string subsheetid = node.Attributes["subsheetid"].Value;

                //try
                //{
                XmlNode Subsheetid_precondition = doc.SelectSingleNode(".//ns:object/ns:process/ns:stage[@type='Start'][ns:subsheetid='" + subsheetid + "']", ns);
                string precondition_narrative = Subsheetid_precondition.SelectSingleNode("..").SelectSingleNode("./ns:preconditions/ns:condition/@narrative", ns).Value;
                try
                {
                    if (precondition_narrative == "" || precondition_narrative == null)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição preconditions na página");
                    }
                }
                catch
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição preconditions na página");
                }
                try
                {
                    string postconditions_narrative = doc.SelectSingleNode(".//ns:object/ns:process/ns:stage[@type='Start'][ns:subsheetid='" + subsheetid + "']/ns:postconditions/ns:condition/@narrative", ns).Value;
                    //    string postconditions_narrative = Subsheetid_postcondition.SelectSingleNode("..").SelectSingleNode("./ns:postconditions/ns:condition/@narrative", ns).Value;

                    if (postconditions_narrative == "" || postconditions_narrative == null)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição postconditions na página");
                    }
                }
                catch
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição postconditions na página");
                }
            }
        }
        public void Check_Narrative(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='SubSheetInfo']/ns:narrative", ns);

            foreach (XmlNode node in Nodes)
            {
                if (node.InnerText == "")
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe narrativa na página.");
                }
            }
        }
        public void Tamanho_blocos(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            /*
             * Itens/Collections devem ter 2 blocos de altura e 8 blocos de largura. 
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList process = doc.SelectNodes(".//ns:object/ns:process/ns:stage", ns);
            foreach (XmlNode stage in process) //cada objeto
            {

                if (stage.Attributes["type"].Value == "Data" || stage.Attributes["type"].Value == "Collection")
                {
                    try
                    {
                        string nomeStage = stage.Attributes["name"].Value;
                        int currentw = int.Parse(stage.SelectSingleNode("./ns:display/@w", ns).Value);
                        int currenth = int.Parse(stage.SelectSingleNode("./ns:display/@h", ns).Value);

                        if (currentw != 90 && currenth != 60)
                        {
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                            excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Data Item: " + stage.Attributes["name"].Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", stage.Attributes["type"].Value + " Name: '" + stage.Attributes["name"].Value + "' fora do padrão, devem ter 2 blocos de altura e 8 blocos de largura.");
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
