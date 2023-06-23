using Code_Inspector;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SafeReview.Objetos_Blue_Prism
{
   public class vExcelv
    {
        public class Criar_Workbooks
        {
            public  Application _excelApp;
            private Workbook _workbook;
            private Worksheet _worksheet;


            public void Criar_Workbook()
            {
                _excelApp = new Application();
                _workbook = _excelApp.Workbooks.Add();
            }


            public void Criar_Woksheet(string nome_worksheet)
            {
                //_excelApp.Visible = true;
                _worksheet = _workbook.Worksheets.Add();
                _worksheet.Name = nome_worksheet;
               
            }

            public void Excel_Visible() {
                _excelApp.Visible = true;
            }
            public void scrennUpdate(bool valor) {
                _excelApp.ScreenUpdating = valor;
            }
            public void Escreva_Worksheet(int numero_linha, string coluna, string valor_linha)
            {
               
                // Escreve valores nas células A1 e D2
                _worksheet.Range[coluna + numero_linha].Value = valor_linha;

                // Salva o arquivo com o nome "teste.xlsx" na pasta atual do projeto
                //workbook.SaveAs("teste.xlsx");

                // Fecha o workbook e o Excel
                //workbook.Close();
                //excel.Quit();

            }

            public void criar_cabecalho_Objetos()
            {
                _workbook.Worksheets["Conferencia_Objetos"].select();
                _worksheet.Range["A1"].Value = "Erro / Alerta / Notificação";
                _worksheet.Range["B1"].Value = "Nome do Objeto";
                _worksheet.Range["C1"].Value = "Elemento ou Ação";
                _worksheet.Range["D1"].Value = "Descrição do Erro ou Alerta";
            }

            public void criar_cabecalho_Processo()
            {
                _workbook.Worksheets["Conferencia_Processo"].select();
                _worksheet.Range["A1"].Value = "Erro / Alerta / Notificação";
                _worksheet.Range["B1"].Value = "Nome Processo";
                _worksheet.Range["C1"].Value = "Nome Página";
                _worksheet.Range["D1"].Value = "Descrição";
            }
            public void criar_implamentation_Tracker()
            {
                _workbook.Worksheets["Preview_IT"].select();
                _worksheet.Range["A1"].Value = "Nome Objeto";
                _worksheet.Range["B1"].Value = "Nome Página";
                _worksheet.Range["C1"].Value = "Publish";
                _worksheet.Range["D1"].Value = "Input_Name";
                _worksheet.Range["E1"].Value = "Input_Narrative";
                _worksheet.Range["F1"].Value = "Output_Name";
                _worksheet.Range["G1"].Value = "Output_Narrative";
                _worksheet.Range["H1"].Value = "Preconditions";
                _worksheet.Range["I1"].Value = "Postconditions";

            }
            public string Read_Range(string Worksheet_name,string Range_position)
            {
                Console.WriteLine("");
                _workbook.Worksheets[Worksheet_name].select();
                string Valor_Range = _worksheet.Range[Range_position].Value;
                return Valor_Range;

            }
        }
    }
}
