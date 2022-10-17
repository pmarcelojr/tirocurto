using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBehind.Loteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mega Sena");
            Console.WriteLine("=========");
            Console.WriteLine();
            MegaSena();
            Console.WriteLine("Loto Fácil");
            Console.WriteLine("=========");
            Console.WriteLine();
            //LotoFacil();
        }

        private static void MegaSena()
        {
            var book = new LinqToExcel.ExcelQueryFactory(@"C:\Users\Juninho\Development\tirocurto\CodeBehind\CodeBehind.Loteria\temp\mega.xlsx");

            var query =
                from row in book.Worksheet("mega")
                let item = new
                {
                    Concurso = row["Concurso"].Cast<int>(),
                    D1 = row["Coluna1"].Cast<int>(),
                    D2 = row["Coluna2"].Cast<int>(),
                    D3 = row["Coluna3"].Cast<int>(),
                    D4 = row["Coluna4"].Cast<int>(),
                    D5 = row["Coluna5"].Cast<int>(),
                    D6 = row["Coluna6"].Cast<int>(),
                }
                where row["Concurso"].Cast<int>() > 0
                select item;

            List<int> numeros = new List<int>();
            numeros.AddRange(query.Select(x => x.D1).ToArray());
            numeros.AddRange(query.Select(x => x.D2).ToArray());
            numeros.AddRange(query.Select(x => x.D3).ToArray());
            numeros.AddRange(query.Select(x => x.D4).ToArray());
            numeros.AddRange(query.Select(x => x.D5).ToArray());
            numeros.AddRange(query.Select(x => x.D6).ToArray());

            var queryGrupo = numeros
                .GroupBy(x => x)
                .Select(x => new { Numero = x.Key, Quantidade = x.Count() }).ToList();

            var ultimo = query.Select(x => x.Concurso).ToList().OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"MEGA SENA total de Resultados {query.Count()}");
            Console.WriteLine("");
            Console.WriteLine($"MEGA SENA ultimo resultado {ultimo}");
            Console.WriteLine("");

            foreach (var item in queryGrupo.OrderByDescending(x => x.Quantidade))
            {
                Console.WriteLine($"Numero {item.Numero} apareceu {item.Quantidade} vezes");
            }

            Console.WriteLine("");
        }

        private static void LotoFacil()
        {
            var book = new LinqToExcel.ExcelQueryFactory(@"C:\Users\Juninho\Development\tirocurto\CodeBehind\CodeBehind.Loteria\temp\lotofacil.xlsx");

            Console.WriteLine("LotoFacil");

            var query =
                from row in book.Worksheet("lotofacil")
                let item = new
                {
                    Concurso = row["Concurso"].Cast<int>(),
                    D1 = row["Bola1"].Cast<int>(),
                    D2 = row["Bola2"].Cast<int>(),
                    D3 = row["Bola3"].Cast<int>(),
                    D4 = row["Bola4"].Cast<int>(),
                    D5 = row["Bola5"].Cast<int>(),
                    D6 = row["Bola6"].Cast<int>(),
                    D7 = row["Bola7"].Cast<int>(),
                    D8 = row["Bola8"].Cast<int>(),
                    D9 = row["Bola9"].Cast<int>(),
                    D10 = row["Bola10"].Cast<int>(),
                    D11 = row["Bola11"].Cast<int>(),
                    D12 = row["Bola12"].Cast<int>(),
                    D13 = row["Bola13"].Cast<int>(),
                    D14 = row["Bola14"].Cast<int>(),
                    D15 = row["Bola15"].Cast<int>()
                }
                where row["Concurso"].Cast<int>() > 0
                    && row["Bola1"].Cast<int>() <= 25
                    && row["Bola2"].Cast<int>() <= 25
                    && row["Bola3"].Cast<int>() <= 25
                    && row["Bola4"].Cast<int>() <= 25
                    && row["Bola5"].Cast<int>() <= 25
                    && row["Bola6"].Cast<int>() <= 25
                    && row["Bola7"].Cast<int>() <= 25
                    && row["Bola8"].Cast<int>() <= 25
                    && row["Bola9"].Cast<int>() <= 25
                    && row["Bola10"].Cast<int>() <= 25
                    && row["Bola11"].Cast<int>() <= 25
                    && row["Bola12"].Cast<int>() <= 25
                    && row["Bola13"].Cast<int>() <= 25
                    && row["Bola14"].Cast<int>() <= 25
                    && row["Bola15"].Cast<int>() <= 25
                select item;

            Console.WriteLine($"Unificar");

            List<int> numerosLoto = new List<int>();
            numerosLoto.AddRange(query.Select(x => x.D1).ToList());
            numerosLoto.AddRange(query.Select(x => x.D2).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D3).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D4).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D5).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D6).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D7).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D8).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D9).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D10).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D11).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D12).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D13).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D14).ToArray());
            numerosLoto.AddRange(query.Select(x => x.D15).ToArray());

            var queryGrupo = numerosLoto
                .GroupBy(x => x)
                .Select(x => new { Numero = x.Key, Quantidade = x.Count() }).ToList();

            var ultimoLoto = query.Select(x => x.Concurso).ToList().OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"LotoFacil total de Resultados {query.Count()}");
            Console.WriteLine("");
            Console.WriteLine($"LotoFacil ultimo resultado {ultimoLoto}");
            Console.WriteLine("");

            foreach (var item in queryGrupo.OrderByDescending(x => x.Quantidade))
            {
                Console.WriteLine($"Numero {item.Numero} apareceu {item.Quantidade} vezes");
            }

            Console.WriteLine("");
        }
    }
}
