using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SafeReview.Objetos_Blue_Prism
{
    class Implentation_Tracker
    {
        
        public static void Leitura_objetos_Tracker(string Local_Release, vExcelv.Criar_Workbooks excel) //encontra os elementos de cada objeto
        {
            int numero_linha_excel = 1;
            string SubsheetID = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList objectNodes = doc.SelectNodes("//ns:object", ns);
            foreach (XmlNode objectNode in objectNodes) //cada objeto
            {
                XmlNodeList subsheets = objectNode.SelectNodes(".//ns:subsheet", ns);
                int contagem_paginas_por_objeto = 0;
                foreach (XmlNode subsheet in subsheets) //cada subsheet
                {
                    if (subsheet.Attributes != null)
                    {
                        Console.WriteLine("published or not: " + subsheet.Attributes["published"].Value);

                        XmlNodeList names = subsheet.SelectNodes("./ns:name", ns);
                        foreach (XmlNode NAME in names) //cada nome
                        {
                            numero_linha_excel += 1;
                            contagem_paginas_por_objeto += 1;
                            SubsheetID = subsheet.Attributes["subsheetid"].Value;

                            excel.Escreva_Worksheet(numero_linha_excel, "A", objectNode.Attributes["name"].InnerText);
                            excel.Escreva_Worksheet(numero_linha_excel, "B", NAME.InnerText);
                            excel.Escreva_Worksheet(numero_linha_excel, "C", "Published = " + subsheet.Attributes["published"].Value);


                            XmlNodeList stagesx = doc.SelectNodes(".//ns:stage",ns);
                            foreach (XmlNode stagex in stagesx) //cada subsheet
                            {
                                XmlNodeList SubsheetIds = stagex.SelectNodes("./ns:subsheetid", ns);
                                foreach (XmlNode SSheet in SubsheetIds)
                                {
                                    if (SSheet.InnerText == SubsheetID)//if (stagex.Attributes["name"].Value == NAME.InnerText && stagex.Attributes["name"].Value)
                                    {
                                        XmlNodeList Inputsx = stagex.SelectNodes("./ns:inputs/ns:input", ns);
                                        foreach (XmlNode Inputx in Inputsx)
                                        {
                                            
                                            string valores = excel.Read_Range("Preview_IT", "D" + numero_linha_excel);
                                            if (valores != null && valores.Contains(Inputx.Attributes["name"].Value, StringComparison.OrdinalIgnoreCase))
                                            { }
                                            else
                                            {
                                                excel.Escreva_Worksheet(numero_linha_excel, "D", Inputx.Attributes["name"].Value + ", " + valores);
                                                //excel.Escreva_Worksheet(numero_linha_excel, "D",Inputx.Attributes["name"].Value);
                                                if (Inputx.Attributes["narrative"] != null)
                                                {
                                                    string valores2 = excel.Read_Range("Preview_IT", "E" + numero_linha_excel);
                                                    if (valores2 != null && valores2.Contains(Inputx.Attributes["narrative"].Value, StringComparison.OrdinalIgnoreCase))
                                                    { }
                                                    else
                                                    {
                                                        excel.Escreva_Worksheet(numero_linha_excel, "E", Inputx.Attributes["narrative"].Value + ", " + valores2);
                                                    }
                                                }
                                            }
                                        }

                                        XmlNodeList Outputsx = stagex.SelectNodes("./ns:outputs/ns:output", ns);
                                        foreach (XmlNode Outputx in Outputsx)
                                        {
                                            string valores = excel.Read_Range("Preview_IT", "F" + numero_linha_excel);
                                            if (valores != null && valores.Contains(Outputx.Attributes["name"].Value, StringComparison.OrdinalIgnoreCase))
                                            { }
                                            else
                                            {
                                                excel.Escreva_Worksheet(numero_linha_excel, "F", Outputx.Attributes["name"].Value + ", " + valores);
                                                // excel.Escreva_Worksheet(numero_linha_excel, "F", Outputx.Attributes["name"].Value);
                                            }
                                            if (Outputx.Attributes["narrative"] != null)
                                            {
                                                string valores2 = excel.Read_Range("Preview_IT", "G" + numero_linha_excel);
                                                if (valores2 != null && valores2.Contains(Outputx.Attributes["narrative"].Value, StringComparison.OrdinalIgnoreCase))
                                                { }
                                                else
                                                {
                                                    excel.Escreva_Worksheet(numero_linha_excel, "G", Outputx.Attributes["narrative"].Value + ", " + valores2);
                                                    //excel.Escreva_Worksheet(numero_linha_excel, "G", Outputx.Attributes["narrative"].Value);
                                                }
                                            }                                                                                 
                                        }

                                        XmlNodeList preconditions = stagex.SelectNodes("./ns:preconditions/ns:condition", ns);
                                        foreach (XmlNode condition in preconditions)
                                        {
                                         
                                            if (condition.Attributes["narrative"].Value != "")
                                            {
                                                Console.WriteLine(condition.Attributes["narrative"].Value);
                                                //print na narrativa caso queira...
                                                excel.Escreva_Worksheet(numero_linha_excel, "H", condition.Attributes["narrative"].Value);
                                            }
                                            XmlNodeList postconditions = stagex.SelectNodes("./ns:postconditions/ns:condition", ns);
                                            foreach (XmlNode conditionx in postconditions)
                                            {
                                                if (conditionx.Attributes["narrative"].Value != "")
                                                {
                                                    Console.WriteLine(conditionx.Attributes["narrative"].Value);
                                                    excel.Escreva_Worksheet(numero_linha_excel, "I", conditionx.Attributes["narrative"].Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void Leitura_process_Tracker(string Local_Release, vExcelv.Criar_Workbooks excel)
        {
            //não finalizado

            XmlDocument doc = new XmlDocument();
            doc.Load(Local_Release);
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");
            XmlNodeList ListNodesA = doc.SelectNodes(".//ns:process/ns:process/ns:stage[ns:preconditions/ns:condition]", ns);
            XmlNodeList ListNodesB = doc.SelectNodes(".//ns:process/ns:process/ns:stage[ns:postconditions/ns:condition]", ns);
            XmlNodeList ListNodesC = doc.SelectNodes(".//ns:process/ns:process/ns:stage[@type='SubSheetInfo']", ns);

            void CheckStage(XmlNodeList ListNodes, vExcelv.Criar_Workbooks excel)
            {

            }
        }
    }
}
