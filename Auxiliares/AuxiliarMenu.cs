using System;
using System.Collections.Generic;
using System.Globalization;

namespace ChallengeCarePlus.Auxiliares
{
    public static class AuxiliarMenu
    {
        public static string EscolherOpcao(string titulo, List<string> opcoes)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"-- {titulo.ToUpper()} --\n");

                for (int i = 0; i < opcoes.Count; i++)
                    Console.WriteLine($"{i + 1}. {opcoes[i]}");

                Console.Write("\nEscolha uma opção (Nº): ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int escolha) &&
                    escolha >= 1 && escolha <= opcoes.Count)
                {
                    return opcoes[escolha - 1];   
                }

                ExibirErro("Opção inválida. Tente novamente.");
            }
        }


        public static void ExibirErro(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERRO: {msg}");
            Console.ResetColor();
            Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
        }

        public static void ExibirSucesso(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSUCESSO: {msg}");
            Console.ResetColor();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static DateTime ObterEntradaData(string prompt)
        {
            DateTime data;
            while (true)
            {
                Console.Write($"\n{prompt} (dd/mm/aaaa): ");
                string entrada = Console.ReadLine();

                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                    return data;

                ExibirErro("Data inválida. Use o formato dd/mm/aaaa.");
            }
        }

        public static string ObterEntradaString(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write($"\n{prompt}: ");
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                ExibirErro($"O campo '{prompt}' não pode ficar vazio.");
            }
        }

        public static double ObterEntradaDoublePositivo(string prompt)
        {
            double quantidade;
            while (true)
            {
                Console.Write($"\n{prompt}: ");
                if (double.TryParse(Console.ReadLine(), out quantidade) && quantidade > 0)
                    return quantidade;

                ExibirErro("Valor inválido! Deve ser um número positivo.");
            }
        }
    }
}
