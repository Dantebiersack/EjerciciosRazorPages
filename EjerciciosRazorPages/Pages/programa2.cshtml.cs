using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace EjerciciosRazorPages.Pages
{
    public class programa2Model : PageModel
    {
        [BindProperty]
        public string FraseACodificar { get; set; } = "";

        [BindProperty]
        public int N { get; set; } = 3;

        public string FraseCifrada { get; set; } = "";
        public string FraseDescifrada { get; set; } = "";

        char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public void OnGet()
        {
        }

        public void OnPostCodificar()
        {
            FraseCifrada = Codificar(FraseACodificar, N);
        }

        public void OnPostDecodificar()
        {
            FraseDescifrada = DeCodificar(FraseACodificar, N);
        }

        public string Codificar(string texto, int n)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in texto.ToUpper())
            {
                int idx = Array.IndexOf(abc, c);
                if (idx >= 0)
                {
                    int nuevoIdx = (idx + n) % abc.Length;
                    resultado.Append(abc[nuevoIdx]);
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }

        public string DeCodificar(string texto, int n)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in texto.ToUpper())
            {
                int idx = Array.IndexOf(abc, c);
                if (idx >= 0)
                {
                    int nuevoIdx = (idx - n + abc.Length) % abc.Length;
                    resultado.Append(abc[nuevoIdx]);
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }
    }
}
