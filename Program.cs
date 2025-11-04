using ChallengeCarePlus.Interfaces;
using ChallengeCarePlus.Repositorios;
using ChallengeCarePlus.Servicos;
using ChallengeCarePlus.Auxiliares;
using System;
using System.Collections.Generic;

namespace ChallengeCarePlus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepositorioRefeicao repositorio = new RepositorioRefeicao();
            ServicoRefeicao servico = new ServicoRefeicao(repositorio);

            List<string> opcoesMenuPrincipal = new List<string>
            {
                "Adicionar refeição",
                "Listar registros",
                "Exibir estatísticas",
                "Sair"
            };

            while (true)
            {
                string escolha = AuxiliarMenu.EscolherOpcao("NUTRICARE: REGISTRO DE ALIMENTAÇÃO", opcoesMenuPrincipal);

                switch (escolha)
                {
                    case "Adicionar refeição":
                        servico.AdicionarRefeicaoAcao();
                        break;
                    case "Listar registros":
                        servico.ListarRegistrosAcao();
                        break;
                    case "Exibir estatísticas":
                        servico.ExibirEstatisticasAcao();
                        break;
                    case "Sair":
                        Console.WriteLine("\nPrograma encerrado.");
                        return;
                    case "Inválido":
                        break;
                }
            }
        }
    }
}
