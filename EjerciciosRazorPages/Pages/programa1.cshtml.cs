using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class programa1Model : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";

        [BindProperty]
        public string altura { get; set; } = "";

        public double imc = 0;
        public string clasificacion = "";
        public string nombreImagen = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            double pesoVal = Convert.ToDouble(peso);
            double alturaVal = Convert.ToDouble(altura);

            imc = pesoVal / (alturaVal * alturaVal);

            if (imc < 18)
            {
                clasificacion = "Peso Bajo";
                nombreImagen = "bajo.png";
            }
            else if (imc < 25)
            {
                clasificacion = "Peso Normal";
                nombreImagen = "normal.png";
            }
            else if (imc < 27)
            {
                clasificacion = "Sobrepeso";
                nombreImagen = "sobrepeso.png";
            }
            else if (imc < 30)
            {
                clasificacion = "Obesidad grado I";
                nombreImagen = "obesidad1.png";
            }
            else if (imc < 40)
            {
                clasificacion = "Obesidad grado II";
                nombreImagen = "obesidad2.png";
            }
            else
            {
                clasificacion = "Obesidad grado III";
                nombreImagen = "obesidad3.png";
            }

            ModelState.Clear();
        }
    }
}
