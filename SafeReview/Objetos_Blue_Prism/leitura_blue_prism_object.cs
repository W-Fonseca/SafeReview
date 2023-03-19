
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace SafeReview.Objetos_Blue_Prism
{
    class leitura_blue_prism_object
    {
            public static void Leitura_objetos(string Local_Release, vExcelv.Criar_Workbooks excel) //encontra os elementos de cada objeto
            {
                int numero_linha_excel = 1;
                string nome_objeto = "";

                //Criar_Workbook excel = instance Criar_Workbook();
                excel.Criar_Woksheet("Conferencia_Objetos");
                excel.criar_cabecalho_Objetos();

                XmlDocument doc = new XmlDocument();
                doc.Load(Local_Release);
                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("ns", "http://www.blueprism.co.uk/product/process");

                XmlNodeList objectNodes = doc.SelectNodes("//ns:object", ns);

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
                    // identificar cada nome de páginas do objeto. e saber se está publicado ou não... é bom colocar um contador para saber a quantidade de paginas, na fiat o maximo é 15.
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
                                Console.WriteLine("subsheet Name: " + NAME.InnerText + " Published= " + subsheet.Attributes["published"].Value);

                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Notificação");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação: " + NAME.InnerText);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Published = " + subsheet.Attributes["published"].Value);

                            }

                        }
                    }
                    if (contagem_paginas_por_objeto > 15)
                    {
                        numero_linha_excel += 1;
                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                        excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Objeto");
                        excel.Escreva_Worksheet(numero_linha_excel, "D", "Objeto com numero excessivo de páginas, o maximo é 15, quantidade criada é: " + contagem_paginas_por_objeto);
                    }

                    contagem_paginas_por_objeto = 0;
                    // posso ler as referencias de dll e importações ex.: system.collection.generic e ler linguagem utilizada no objeto, ex visual basic, codigo usado.



                    // identifica cada pagina e estagio do objeto. obs.: apesar que aqui é tudo stage.
                    XmlNodeList stages = objectNode.SelectNodes(".//ns:stage", ns);
                    int stagios_contagem = 0;
                    string nome_pagina = "";
                    bool WaitStart_Check = false;
                    bool Exception_Check = false;
                    foreach (XmlNode stage in stages) //cada subsheet
                    {
                        if (stage.Attributes["type"].Value != "Data" && stage.Attributes["type"].Value != "Note" && stage.Attributes["type"].Value != "Block" && stage.Attributes["type"].Value != "Anchor")
                        {
                            stagios_contagem += 1;
                        }

                        Console.WriteLine("nome: " + stage.Attributes["name"].Value + " Type: " + stage.Attributes["type"].Value);

                        if (stage.Attributes["name"].Value == "Attach" && stage.Attributes["type"].Value == "SubSheetInfo" && nome_objeto == "e-Gate - Extração de relatório")// teste
                        {
                            Console.WriteLine("PAUSE"); //pause
                        }


                        if (stage.Attributes != null && stage.Attributes["type"].Value == "SubSheetInfo" && stage.Attributes["name"].Value != "Clean Up")
                        {
                            if (WaitStart_Check == false && nome_pagina != "" && nome_pagina != "Attach") // pagina sem wait.
                            {
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Ação sem Wait");
                            }


                            if (stagios_contagem - 1 > 15)
                            {
                                Console.WriteLine("erro: página " + nome_pagina + " maior do que 15 ações."); //preencher erro na planilha.
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Numero excessivo de ações, o maximo é 15, quantidade criada é: " + stagios_contagem);
                            }

                            if (Exception_Check == false && nome_pagina != "" && nome_pagina != "Attach")
                            {
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Página sem exception");

                            }

                            WaitStart_Check = false; //nome da página do objeto
                            nome_pagina = stage.Attributes["name"].Value;
                            stagios_contagem = 0; // zerar contagem de  stagios
                            Exception_Check = false;
                            Console.WriteLine("Page: " + nome_pagina);

                            XmlNodeList narrativas = stage.SelectNodes("./ns:narrative", ns);

                            if (narrativas.Count == 0)
                            {
                                Console.WriteLine("não existe narrativa"); //preencher erro na planilha 
                                numero_linha_excel += 1;
                                excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição da ação");
                            }
                            else
                            {
                                foreach (XmlNode narrativa in narrativas) //cada nome
                                {
                                    Console.WriteLine("narrativa: " + narrativa.InnerText);
                                    //print na narrativa caso queira...
                                }
                            }


                        }
                        if (stage.Attributes["type"].Value == "Start")
                        {
                            XmlNodeList preconditions = stage.SelectNodes("./ns:preconditions/ns:condition", ns);
                            foreach (XmlNode condition in preconditions)
                            {
                                if (condition.Attributes["narrative"].Value != "")
                                {
                                    Console.WriteLine(condition.Attributes["narrative"].Value);
                                    //print na narrativa caso queira...
                                }
                                else
                                {

                                    numero_linha_excel += 1;
                                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                    excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição preconditions na página");
                                }
                            }


                        }
                        if (stage.Attributes["type"].Value == "Start")
                        {
                            stagios_contagem += 1;
                            XmlNodeList postconditions = stage.SelectNodes("./ns:postconditions/ns:condition", ns);
                            foreach (XmlNode condition in postconditions)
                            {
                                if (condition.Attributes["narrative"].Value != "")
                                {
                                    Console.WriteLine(condition.Attributes["narrative"].Value);
                                    //print na narrativa caso queira...
                                }
                                else
                                {
                                    Console.WriteLine("erro: não existe postconditions"); // preencher erro na planilha
                                    numero_linha_excel += 1;
                                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                    excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Não existe descrição postconditions na página");
                                }
                            }
                        }

                        if (stage.Attributes["type"].Value == "WaitStart")
                        {
                            // <timeout>[GLOBAL TIME OUT - M]</timeout>
                            WaitStart_Check = true;
                            XmlNodeList timeouts = stage.SelectNodes(".//ns:timeout", ns);
                            foreach (XmlNode timeout in timeouts)
                            {
                                Console.WriteLine(timeout.InnerText);

                                Regex regex = new Regex(@"\[[^\]]*\]");

                                Match match = regex.Match(timeout.InnerText);
                                if (match.Success)
                                {
                                    int index = match.Index;
                                    if ((index > 0 && timeout.InnerText[index - 1] != ' ') || (index + match.Length < timeout.InnerText.Length && timeout.InnerText[index + match.Length] != ' ')) //encontra se existe algum valor antes e depois de [] de timeout waitstart
                                    {
                                        Console.WriteLine("Há algo antes do [ ou depois de ]");
                                        numero_linha_excel += 1;
                                        excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                        excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                        excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                        excel.Escreva_Worksheet(numero_linha_excel, "D", "timeout: " + stage.Attributes["name"].Value + " com valor fixo. ");
                                    }

                                }


                            }
                        }

                        if (stage.Attributes["type"].Value == "Exception")
                        {
                            Exception_Check = true;
                            XmlNodeList Exceptions = stage.SelectNodes("./ns:exception", ns);
                            foreach (XmlNode Exception in Exceptions)
                            {
                                Console.WriteLine(Exception.Attributes["type"].Value);
                                if (Exception.Attributes["type"].Value != "System Exception" && Exception.Attributes["type"].Value != "Business Exception")
                                {
                                    numero_linha_excel += 1;
                                    excel.Escreva_Worksheet(numero_linha_excel, "A", "Erro");
                                    excel.Escreva_Worksheet(numero_linha_excel, "B", nome_objeto);
                                    excel.Escreva_Worksheet(numero_linha_excel, "C", "Ação:" + nome_pagina);
                                    excel.Escreva_Worksheet(numero_linha_excel, "D", "Exception com: " + Exception.Attributes["type"].Value + " o correto é: System Exception ou Business Exception");
                                }
                            }
                        }
                    }
                }
            }
    }
}
