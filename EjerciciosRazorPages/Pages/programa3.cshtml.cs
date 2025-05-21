using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EjerciciosRazorPages.Pages
{
    public class programa3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public int N { get; set; }

        public double ResultadoBinomial { get; set; }
        public double ResultadoDirecto { get; set; }
        public List<string> Pasos { get; set; } = new();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ResultadoBinomial = EvaluarBinomial(A, B, X, Y, N);
            ResultadoDirecto = Math.Pow((A * X + B * Y), N);
        }

        private double EvaluarBinomial(double a, double b, double x, double y, int n)
        {
            double suma = 0;
            Pasos.Clear();

            for (int k = 0; k <= n; k++)
            {
                double coeficiente = Binomial(n, k);
                double ax = a * x;
                double by = b * y;
                double potAX = Math.Pow(ax, n - k);
                double potBY = Math.Pow(by, k);
                double term = coeficiente * potAX * potBY;

                Pasos.Add(
                    $"({n},{k}) · (a·x)^{n - k} · (b·y)^{k} = " +
                    $"{coeficiente} · ({ax})^{n - k} · ({by})^{k} = {term:F2}"
                );
                suma += term;
            }

            Pasos.Add($"Resultado final usando binomio: {suma:F2}");
            return suma;
        }

        private double Binomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private double Factorial(int num)
        {
            double res = 1;
            for (int i = 2; i <= num; i++)
                res *= i;
            return res;
        }
    }
}
