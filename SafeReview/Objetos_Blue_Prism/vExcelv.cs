using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeReview.Objetos_Blue_Prism
{
   public class vExcelv
    {
        public class Criar_Workbooks
        {
            private Application _excelApp;
            private Workbook _workbook;
            private Worksheet _worksheet;


            public void Criar_Workbook()
            {
                _excelApp = new Application();
                _workbook = _excelApp.Workbooks.Add();
            }

            public void Criar_Woksheet(string nome_worksheet)
            {
                _excelApp.Visible = true;
                _worksheet = _workbook.Worksheets.Add();
                _worksheet.Name = nome_worksheet;
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
        }
    }
}
