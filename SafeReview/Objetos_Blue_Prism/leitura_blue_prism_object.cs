
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SafeReview.Objetos_Blue_Prism
{
    class leitura_blue_prism_object
    {
        int numero_linha_excel = 1;

        public static void Leitura_objetos(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual) //encontra os elementos de cada objeto
        {

            leitura_blue_prism_object programa_objeto = new leitura_blue_prism_object();
            excel.Criar_Woksheet(MainWindow.dictionary["criar_cabecalho_Objetos_title"].ToString());
            excel.criar_cabecalho_Objetos();
            
            programa_objeto.Check_element_and_Attributes(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_Publish(Local_Release, excel, DictionaryAtual);
            programa_objeto.Count_Page(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_wait_time(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_All_Exception(Local_Release, excel, DictionaryAtual);
            programa_objeto.Preconditions_PostConditions(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_Narrative(Local_Release, excel, DictionaryAtual);
            programa_objeto.Count_Stages_InPage(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_Contais_Stage_InPage(Local_Release, excel, DictionaryAtual);
            programa_objeto.Tamanho_blocos(Local_Release, excel, DictionaryAtual);
            programa_objeto.Color_Block(Local_Release, excel, DictionaryAtual);
            programa_objeto.Identif_Subsheets_And_Actions(Local_Release, excel, DictionaryAtual);
            programa_objeto.Search_Attach(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_Exceptions(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_Environment(Local_Release, excel, DictionaryAtual);
            programa_objeto.CheckAllHardCodeProcess(Local_Release, excel, DictionaryAtual);
            programa_objeto.Check_SendkeysAndMouseClick(Local_Release, excel, DictionaryAtual);

        }

        public void Check_element_and_Attributes(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList elements = doc.SelectNodes(".//ns:object/ns:process//ns:element[ns:type]", ns);
            // XmlNodeList elements = doc.SelectNodes(".//ns:object/ns:process//ns:element/ns:element[ns:type]", ns);
            foreach (XmlNode element in elements) //cada objeto
            {
                Check_Nome_Elemento validador = new Check_Nome_Elemento();
                if (validador.ValidarNome(element.Attributes["name"].Value) == false)
                {
                    XmlNode ParentStage = element;

                    while (ParentStage != null && ParentStage.Name != "object")
                    {
                        ParentStage = ParentStage.SelectSingleNode("..");
                    }
                    
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", ParentStage.Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + element.Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_element_and_Attributes_case1"].ToString());
                }

                XmlNodeList attributes = element.SelectNodes("./ns:attributes/ns:attribute", ns);

                foreach (XmlNode attribute in attributes) //cada atributos
                {
                    if (attribute.Attributes["name"].Value == "ScreenVisible" && attribute.Attributes["inuse"] != null)
                    {

                        XmlNode ParentStage = element;

                        while (ParentStage != null && ParentStage.Name != "object")
                        {
                            ParentStage = ParentStage.SelectSingleNode("..");
                        }
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", ParentStage.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + element.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "ScreenVisible = True");
                        //(ScreenVisible não pode estar marcado, pois cria uma dependencia da aplicação estar visivel mesmo estando minimizada)
                    }

                    else if (attribute.Attributes["name"].Value == "Visible" && attribute.Attributes["inuse"] != null) //erro encontrado, não pode ter Visible aplicado.
                    {

                        XmlNode ParentStage = element;

                        while (ParentStage != null && ParentStage.Name != "object")
                        {
                            ParentStage = ParentStage.SelectSingleNode("..");
                        }
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", ParentStage.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Elemento: " + element.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Visible = True");
                        //(ScreenVisible não pode estar marcado, pois cria uma dependencia da aplicação estar visivel mesmo estando minimizada)
                    }
                }
            }
        }
        public void Check_Publish(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns); //appdef linha 5
            foreach (XmlNode Node in Nodes)
            {
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                excel.Escreva_Worksheet(numero_linha_excel, "B", Node.SelectSingleNode("..").Attributes["name"].Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Node.SelectSingleNode("./ns:name", ns).InnerText);
                excel.Escreva_Worksheet(numero_linha_excel, "D", "Published: " + Node.Attributes["published"].Value);
            }
        }

        public void Check_Contais_Stage_InPage(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Alerta"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Contais_Stage_InPage_case1"].ToString()+" 'Exception'");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='WaitStart'][ns:subsheetid='" + subsheetid + "']", ns) == null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Alerta"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Contais_Stage_InPage_case1"].ToString() + " 'Wait'");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Recover'][ns:subsheetid='" + subsheetid + "']", ns) != null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Contais_Stage_InPage_case2"].ToString()+ " 'Recover'");
                }

                if (doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Resume'][ns:subsheetid='" + subsheetid + "']", ns) != null)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Contais_Stage_InPage_case2"].ToString() +" 'Resume");
                }


                // XmlNodeList Stages = doc.SelectNodes(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[ns:subsheetid='" + subsheetid + "']/@type='Exception'", ns);
            }
        }
        public void Count_Page(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Alerta"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", Node.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Object");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Count_Page_case1"].ToString() + " "+ count_page);
                    }
                    name_process = Node.SelectSingleNode("..").Attributes["name"].Value;
                    count_page = 1;
                }
            }
        }

        public void Count_Stages_InPage(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Count_Stages_InPage_Initialfrase"].ToString() + " " + contagem_stagios + " "+ DictionaryAtual["Count_Stages_InPage_finalyfrase"].ToString());
                }
            }
            
        }

        public void Check_wait_time(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * Os timeouts utilizados nas condições dos waits estão definidas com variáveis globais alocadas na action Initilize do BO, sendo no mínimo: Global Timeout - S | Global Timeout - M | Global Timeout - L, junto com as demais variáveis globais
             * 
             */
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
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", timeout.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "timeout: " + timeout.SelectSingleNode("..").Attributes["name"].Value + " "+ DictionaryAtual["Check_wait_time_case1"].ToString() + " " + timeout.InnerText);
                    }
                }
                else
                {
                    string subsheetid = timeout.SelectSingleNode("..").SelectSingleNode("./ns:subsheetid", ns).InnerText;
                    string nome_Pagina = doc.SelectSingleNode(".//ns:object/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;

                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", timeout.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + nome_Pagina);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "timeout: " + timeout.SelectSingleNode("..").Attributes["name"].Value + " "+ DictionaryAtual["Check_wait_time_case1"].ToString() + " " + timeout.InnerText);

                }
            }
        }
        public void Check_All_Exception(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + nome_Pagina);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception "+ DictionaryAtual["Check_All_Exception_initialfrase"].ToString() + ": " + Exception.Attributes["type"].Value +" "+ DictionaryAtual["Check_All_Exception_finalyfrase"].ToString());
                }
            }
        }
        public void Preconditions_PostConditions(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                string precondition_narrative = Subsheetid_precondition.SelectSingleNode("..").SelectSingleNode("./ns:preconditions/ns:condition/@narrative", ns)?.Value ?? "";
                try
                {
                    if (precondition_narrative == "" || precondition_narrative == null)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["precondition_postcondition_precondition"].ToString());
                    }
                }
                catch
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["precondition_postcondition_precondition"].ToString());
                }
                try
                {
                    string postconditions_narrative = doc.SelectSingleNode(".//ns:object/ns:process/ns:stage[@type='Start'][ns:subsheetid='" + subsheetid + "']/ns:postconditions/ns:condition/@narrative", ns).Value;
                    //    string postconditions_narrative = Subsheetid_postcondition.SelectSingleNode("..").SelectSingleNode("./ns:postconditions/ns:condition/@narrative", ns).Value;

                    if (postconditions_narrative == "" || postconditions_narrative == null)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["precondition_postcondition_postconditions"].ToString());
                    }
                }
                catch
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["precondition_postcondition_postconditions"].ToString());
                }
            }
        }
        public void Check_Narrative(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * O campo de descrição de cada página está preenchido com o resumo do que nela será executado
             */
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
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Narrative_case1"].ToString());
                }
            }
        }
        public void Tamanho_blocos(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
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
                            excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                            excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Data Item: " + stage.Attributes["name"].Value);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", stage.Attributes["type"].Value + " Name: '" + stage.Attributes["name"].Value + "' "+ DictionaryAtual["obj_Tamanho_blocos_case1"].ToString());
                        }
                    }
                    catch { }
                }
            }
        }
        public void Color_Block(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * O bloco 'Input' tem a cor de fundo #0000FF
             * O bloco 'Local' tem a cor de fundo #008000
             * Os blocos que incluem 'Global' tem a cor de fundo #ED7D31
             * O bloco 'Output' tem a cor de fundo #00CCFF
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='Block']", ns);
            foreach (XmlNode stage in ListNodes)
            {

                string objectid = stage.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns)?.InnerText ?? "";
                string Name_page = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']/ns:name", ns)?.InnerText ?? "Main Page";

                if (stage.Attributes["name"].Value.Contains("Global", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {
                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "ED7D31")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Color_Block_MainPage_case1"].ToString()+" '" + stage.Attributes["name"].Value + "' = 'Global' " +DictionaryAtual["Color_Block_MainPage_case2"].ToString()+ " 'ED7D31'");
                    }
                }

                if (stage.Attributes["name"].Value.Contains("Input", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {

                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "0000FF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Color_Block_MainPage_case1"].ToString()+" '" + stage.Attributes["name"].Value + "' = 'Input' "+ DictionaryAtual["Color_Block_MainPage_case2"].ToString() +" '0000FF'");
                    }
                }

                if (stage.Attributes["name"].Value.Contains("Local", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {

                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "008000")
                    {

                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Color_Block_MainPage_case1"].ToString() + " '" + stage.Attributes["name"].Value + "' = 'Local' " + DictionaryAtual["Color_Block_MainPage_case2"].ToString() + " '008000'");
                    }
                }

                if (stage.Attributes["name"].Value.Contains("Output", StringComparison.OrdinalIgnoreCase) && stage.Attributes["type"].Value == "Block")
                {

                    if (stage.SelectSingleNode("./ns:font/@color", ns).Value != "00CCFF")
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Notificacao"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", stage.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Color_Block_MainPage_case1"].ToString() + " '" + stage.Attributes["name"].Value + "' = 'Output' " + DictionaryAtual["Color_Block_MainPage_case2"].ToString() + " '00CCFF'");
                    }
                }
            }
        }
        public void Identif_Subsheets_And_Actions(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * Nenhum objeto contém uma ação que chame uma action do próprio objeto, exceto attach e dettach nem de qualquer outro objeto
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='SubSheet']", ns);
            foreach (XmlNode node in Nodes)
            {
                string objectid = node.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string subsheetid = node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                string Name_page = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']/ns:name", ns)?.InnerText ?? "Main Page";

                if (node.Attributes["name"].Value.Contains("Attach", StringComparison.OrdinalIgnoreCase) == false && node.Attributes["name"].Value.Contains("Dettach", StringComparison.OrdinalIgnoreCase) == false)
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Identif_Subsheets_And_Actions_case1_initialfrase"].ToString()+" '" + node.Attributes["name"].Value +"' " +DictionaryAtual["Identif_Subsheets_And_Actions_case1_finalyfrase"].ToString());
                }
            }
            XmlNodeList Nodes2 = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='Action']", ns);
            foreach (XmlNode node in Nodes2)
            {
                string objectid = node.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string subsheetid = node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                string Name_page = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']/ns:name", ns)?.InnerText ?? "Main Page";
                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                excel.Escreva_Worksheet(numero_linha_excel, "B", node.SelectSingleNode("..").Attributes["name"].Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + Name_page);
                excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Identif_Subsheets_And_Actions_case2_initialfrase"].ToString() + " '" + node.Attributes["name"].Value + "' " + DictionaryAtual["Identif_Subsheets_And_Actions_case1_finalyfrase"].ToString());
            }
        }
        public void Search_Attach(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * O Business Object tem uma ação 'Attach' que lê o status conectado antes de ser executada
             * Todas as Actions do Business Object começam com o stage Wait após o attach para verificar se o aplicativo está na tela correta (precisei aproveitar o loop não deu para criar uma nova classe)
             */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList Nodes = doc.SelectNodes(".//ns:object/ns:process/ns:subsheet", ns);

            foreach (XmlNode Node in Nodes)
            {

                string objectid = Node.SelectSingleNode("..").SelectSingleNode("..").Attributes["id"].Value;
                string objectname = Node.SelectSingleNode("..").SelectSingleNode("..").Attributes["name"].Value;
                string namepage = Node.SelectSingleNode("./ns:name", ns).InnerText;
                string SubsheetID = Node.Attributes["subsheetid"].Value;
                string SubsheetIDAttach = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='SubSheet'][ns:subsheetid='" + SubsheetID + "']/ns:processid", ns)?.InnerText ?? null;

                XmlNode CheckAttach = null;
                bool Pageattach = false;
                if (SubsheetIDAttach != null)
                {
                    CheckAttach = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Navigate']/ns:subsheetid['" + SubsheetIDAttach + "']", ns).SelectSingleNode("..").SelectSingleNode(".//ns:id['AttachApplication']", ns);
                }
                if (CheckAttach == null)
                {
                    CheckAttach = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Navigate'][ns:subsheetid='" + SubsheetID + "']", ns)?.ParentNode?.SelectSingleNode(".//ns:id['AttachApplication']", ns);
                    if (CheckAttach != null)
                    {
                        Pageattach = true;
                    }
                }
                if (CheckAttach == null && namepage != "Clean Up")
                {
                    numero_linha_excel += 1;
                    excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                    excel.Escreva_Worksheet(numero_linha_excel, "B", objectname);
                    excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + namepage);
                    excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Search_Attach_case1"].ToString());
                }
                else if (CheckAttach != null && namepage != "Clean Up" && Pageattach == false)
                {
                    string StartOnsucess = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@type='Start'][ns:subsheetid='" + SubsheetID + "']/ns:onsuccess", ns).InnerText;
                    string processID = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@stageid='" + StartOnsucess + "']/ns:processid", ns)?.InnerText ?? null;
                    string WaitOnsucess = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@stageid='" + StartOnsucess + "']/ns:onsuccess", ns)?.InnerText ?? null;
                    if (processID != SubsheetIDAttach)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", objectname);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + namepage);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Search_Attach_case2"].ToString());
                    }
                    if (WaitOnsucess != null) // <-- Todas as Actions do Business Object começam com o stage Wait após o attach para verificar se o aplicativo está na tela correta
                    {
                        string WaitCheck = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:stage[@stageid='" + WaitOnsucess + "']", ns).Attributes["type"].Value;

                        if (WaitCheck != "WaitStart")
                        {
                            numero_linha_excel += 1;
                            excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                            excel.Escreva_Worksheet(numero_linha_excel, "B", objectname);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", DictionaryAtual["leitura_blue_prism_object_acao"].ToString() + namepage);
                            excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Search_Attach_case3"].ToString());
                        }
                    }
                }
            }
        }
        public void Check_Exceptions(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
            * As exceções possuem "Name" e "Type" iguais
            * O texto do campo Exception Detail não se repete para mais de uma Exception do Processo
            */

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='Exception']", ns);

            Dictionary<string, string> ExceptionDetails = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string nome_Pagina;

            foreach (XmlNode Node in ListNodes)
            {
                string nome_stage = Node.Attributes["name"].Value;
                if (Node.SelectSingleNode("./ns:exception/@detail", ns).Value != null && Node.SelectSingleNode("./ns:exception/@type", ns).Value != null && Node.SelectSingleNode("./ns:exception/@usecurrent", ns) == null)
                {
                    nome_Pagina = null;
                    try
                    {
                        string subsheetid = Node.SelectSingleNode("./ns:subsheetid", ns).InnerText;
                        nome_Pagina = doc.SelectSingleNode(".//ns:object/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns).SelectSingleNode("./ns:name", ns).InnerText;
                    }
                    catch { nome_Pagina = "Main Page"; }
                    if (ExceptionDetails.ContainsKey(nome_stage + " - " + Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value))
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", Node.SelectSingleNode("..").Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Exceptions_initialfrase"].ToString() + nome_Pagina + DictionaryAtual["Check_Exceptions_middlefrase"].ToString() + nome_stage + DictionaryAtual["Check_Exceptions_finalyfrase"].ToString() + ExceptionDetails[nome_stage + " - " + Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value]);
                    }
                    else
                    {
                        ExceptionDetails.Add(nome_stage + " - " + Node.SelectSingleNode("./ns:exception/@type", ns).Value + " - " + Node.SelectSingleNode("./ns:exception/@detail", ns).Value, "Pagina: [" + nome_Pagina + "] Exception Name: [" + nome_stage + "]");
                    }
                }
            }
        }
        public void Check_Environment(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * Nenhuma variável de ambiente está sendo chamada pelo objeto (devem ser chamadas pelo processo)
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[ns:exposure='Environment']", ns);

            foreach (XmlNode Node in ListNodes)
            {
                XmlNode ParentStage = Node;

                while (ParentStage != null && ParentStage.Name != "object")
                {
                    ParentStage = ParentStage.SelectSingleNode("..");
                }
                string objectid = ParentStage.Attributes["id"].Value;
                string subsheetid = Node.SelectSingleNode("./ns:subsheetid", ns)?.InnerText ?? "";
                string Name_page = doc.SelectSingleNode(".//ns:object[@id='" + objectid + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']/ns:name", ns)?.InnerText ?? "Main Page";

                numero_linha_excel += 1;
                excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                excel.Escreva_Worksheet(numero_linha_excel, "B", ParentStage.Attributes["name"].Value);
                excel.Escreva_Worksheet(numero_linha_excel, "C", Name_page);
                excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_Environment_case1"].ToString() + Node.Attributes["name"].Value);

            }
        }
        public void CheckAllHardCodeProcess(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * Nenhum Data Item/Collection/Stage contém informações codificada diretamente neles que poderiam mudar com o tempo/circunstâncias 
            */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodesA = doc.SelectNodes(".//ns:object/ns:process/ns:stage//@expr", ns);
            XmlNodeList ListNodesB = doc.SelectNodes(".//ns:object/ns:process/ns:stage//@expression", ns);
            XmlNodeList ListNodesC = doc.SelectNodes(".//ns:object/ns:process/ns:stage/ns:initialvalue", ns);
            CheckStage(ListNodesA, excel);
            CheckStage(ListNodesB, excel);
            CheckStage(ListNodesC, excel);

            void CheckStage(XmlNodeList ListNodes, vExcelv.Criar_Workbooks excel)
            {
                foreach (XmlNode stage in ListNodes)
                {
                    Regex regex1 = new Regex(@"\[[^\]]*\]"); // sem '[' e ']'
                    Regex regex2 = new Regex(@"\([^)]*\)"); // sem '(' e ')' 
                    string expression = stage.Value ?? stage.InnerText;
                    Match match1;
                    Match match2;
                    try
                    {
                        match1 = regex1.Match(stage.Value);
                        match2 = regex2.Match(stage.Value);
                    }
                    catch
                    {
                        match1 = regex1.Match(stage.InnerText);
                        match2 = regex2.Match(stage.InnerText);
                    }
                    
                    if (match1.Success == false && match2.Success == false)
                    {
                        if (expression != "" && expression != "Business Exception" && expression != "System Exception" && expression != "True" && expression != "False")
                        {
                            string nome_Pagina;
                            XmlNode ParentStage = stage;

                            while (ParentStage != null && ParentStage.Name != "stage")
                            {
                                ParentStage = ParentStage.SelectSingleNode("..");
                            }

                            XmlNode ParentObject = ParentStage;

                            while (ParentObject != null && ParentObject.Name != "object")
                            {
                                ParentObject = ParentObject.SelectSingleNode("..");
                            }

                            if (ParentStage.Attributes["type"].Value != "Calculation" && ParentStage.Attributes["type"].Value != "MultipleCalculation")
                            {
                                string subsheetid = ParentStage.SelectSingleNode("./ns:subsheetid", ns)?.InnerText ?? "";
                                nome_Pagina = doc.SelectSingleNode(".//ns:object[@id='" + ParentObject.Attributes["id"].Value + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns)?.SelectSingleNode("./ns:name", ns)?.InnerText ?? "Main Page";
                                if(nome_Pagina != "Main Page")
                                { 
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                                excel.Escreva_Worksheet(numero_linha_excel, "B", doc.SelectSingleNode(".//ns:object[@id='" + ParentObject.Attributes["id"].Value +"']/@name", ns).Value);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["CheckAllHardCodeProcess_initialfrase"].ToString() + ParentStage.Attributes["name"].Value + DictionaryAtual["CheckAllHardCodeProcess_finalyfrase"].ToString() + expression);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Check_SendkeysAndMouseClick(string Local_Release, vExcelv.Criar_Workbooks excel, ResourceDictionary DictionaryAtual)
        {
            /*
             * Todos os objetos tem o modo de execução de segundo plano, a menos que incluam cliques globais ou motivos que possam exigir o uso em primeiro plano.
             */
            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            //[not(ns: subsheetid)]"
            XmlNodeList idNodes = doc.SelectNodes(".//ns:object/ns:process/ns:stage[@type='Navigate'][ns:step/ns:action]", ns);

            foreach (XmlNode stage in idNodes)
            {//[ns:exposure='Environment']"
                if (stage?.SelectSingleNode("./ns:step/ns:action[ns:id='WebClick']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='SendKeyEvents']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='SendKeys']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='RegionParentClickCentre']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='UIAClickCentre']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='AAClickCentre']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='ClickWindowCentre']", ns) != null || stage?.SelectSingleNode("./ns:step/ns:action[ns:id='MouseClickCentre']", ns) != null)
                {
                    XmlNodeList Actions = stage.SelectNodes("./ns:step/ns:action/ns:id", ns);

                    if (Actions[0].InnerText != "WebFocus" && Actions[0].InnerText != "ActivateApp")
                    {
                        XmlNode ParentObject = stage;

                        while (ParentObject != null && ParentObject.Name != "object")
                        {
                            ParentObject = ParentObject.SelectSingleNode("..");
                        }

                        string subsheetid = stage.SelectSingleNode("./ns:subsheetid", ns)?.InnerText ?? "";
                        string nome_Pagina = doc.SelectSingleNode(".//ns:object[@id='" + ParentObject.Attributes["id"].Value + "']/ns:process/ns:subsheet[@subsheetid='" + subsheetid + "']", ns)?.SelectSingleNode("./ns:name", ns)?.InnerText ?? "Main Page";

                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", DictionaryAtual["conferencia_paginas_comuns_Erro"].ToString());
                        excel.Escreva_Worksheet(numero_linha_excel, "B", ParentObject.Attributes["name"].Value);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", nome_Pagina);
                        excel.Escreva_Worksheet(numero_linha_excel, "D", DictionaryAtual["Check_SendkeysAndMouseClick_initialfrase"].ToString() + stage.Attributes["name"].Value + DictionaryAtual["Check_SendkeysAndMouseClick_finalyfrase"].ToString());
                    }
                }
            }
        }
    }
}
