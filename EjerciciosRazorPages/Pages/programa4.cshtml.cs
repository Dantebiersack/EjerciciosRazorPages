using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosRazorPages.Pages
{
    public class programa4Model : PageModel
    {
        public int[] Arreglo { get; set; } = Array.Empty<int>();
        public int[] ArregloOrdenado { get; set; } = Array.Empty<int>();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Modas { get; set; } = new();
        public double Mediana { get; set; }

        public void OnPost()
        {
            Random rnd = new();
            Arreglo = Enumerable.Range(0, 20).Select(_ => rnd.Next(0, 101)).ToArray();
            ArregloOrdenado = Arreglo.OrderBy(x => x).ToArray();
            Suma = Arreglo.Sum();
            Promedio = Math.Round(Arreglo.Average(), 2);
            var grupos = Arreglo.GroupBy(x => x)
                                .Select(g => new { Numero = g.Key, Frecuencia = g.Count() })
                                .OrderByDescending(g => g.Frecuencia)
                                .ToList();
            int maxFrecuencia = grupos.First().Frecuencia;
            Modas = grupos.Where(g => g.Frecuencia == maxFrecuencia && maxFrecuencia > 1)
                          .Select(g => g.Numero)
                          .OrderBy(x => x)
                          .ToList();

            int n = ArregloOrdenado.Length;
            if (n % 2 == 0)
                Mediana = (ArregloOrdenado[n / 2 - 1] + ArregloOrdenado[n / 2]) / 2.0;
            else
                Mediana = ArregloOrdenado[n / 2];
        }
    }
}
