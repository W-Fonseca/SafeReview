using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeReview.Objetos_Blue_Prism
{
    public class Check_Nome_Elemento
    {
        private List<string> nomes;

        public Check_Nome_Elemento()
        {
            nomes = new List<string>()
        {
            "button - ",
            "label - ",
            "input - ",
            "window - ",
            "checkbox - ",
            "table - ",
            "select - "
        };
        }

        public bool ValidarNome(string nome)
        {
            foreach (string nom in nomes)
            {

                if (nome.Contains(nom, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                    break;
                }

            }
            return false;
            // return nomes.Contains(nome, StringComparer.OrdinalIgnoreCase);
        }
    }
}
