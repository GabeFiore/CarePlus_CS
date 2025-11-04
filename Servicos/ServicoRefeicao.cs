using ChallengeCarePlus.Interfaces;
using ChallengeCarePlus.Modelos;
using ChallengeCarePlus.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCarePlus.Servicos
{
    public class ServicoRefeicao
    {
        private readonly IRepositorioRefeicao _repositorio;

        public ServicoRefeicao(IRepositorioRefeicao repositorio)
        {
            _repositorio = repositorio;
        }

        // Função para adicionar refeição
        public void AdicionarRefeicaoAcao()
        {
            Console.Clear();
            Console.WriteLine("-- ADICIONAR REFEIÇÃO --\n");

            // 1. Tipo de refeição
            string tipoRefeicao = AuxiliarMenu.EscolherOpcao("Escolha o tipo de refeição", new List<string>
            {
                "Café da manhã", "Almoço", "Lanche", "Jantar", "Ceia"
            });

            // 2. Data
            DateTime data = AuxiliarMenu.ObterEntradaData("Data");

            // 3. Nome do alimento
            string nomeAlimento = AuxiliarMenu.ObterEntradaString("Nome do alimento");

            // 4. Categoria
            string categoria = AuxiliarMenu.EscolherOpcao("Categoria do alimento", new List<string>
            {
                "Saudável", "Ultraprocessado"
            });

            // 5. Quantidade
            double quantidade = AuxiliarMenu.ObterEntradaDoublePositivo("Quantidade");

            // 6. Unidade de medida
            string unidade = AuxiliarMenu.EscolherOpcao("Escolha a unidade de medida", new List<string>
            {
                "gramas (g)", "kilogramas (kg)", "unidades", "mililitros (ml)", "copos"
            });

            // Ajuste da unidade para forma curta
            unidade = unidade.Contains("g") ? "g" :
                   unidade.Contains("kg") ? "kg" :
                   unidade.Contains("ml") ? "ml" :
                   unidade.Contains("copos") ? "copos" :
                   "unidades";

            var novaRefeicao = new Refeicao
            {
                Data = data,
                TipoRefeicao = tipoRefeicao,
                NomeAlimento = nomeAlimento,
                Categoria = categoria,
                Quantidade = quantidade,
                Unidade = unidade
            };

            _repositorio.AdicionarRefeicao(novaRefeicao);
            AuxiliarMenu.ExibirSucesso("Registro salvo com sucesso!");
        }

        // Função para listar registros
        public void ListarRegistrosAcao()
        {
            Console.Clear();
            Console.WriteLine("-- LISTA DE REFEIÇÕES --\n");

            var refeicoes = _repositorio.ObterTodasRefeicoes();

            if (!refeicoes.Any())
            {
                Console.WriteLine("Nenhuma refeição foi registrada ainda.");
            }
            else
            {
                for (int i = 0; i < refeicoes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {refeicoes[i]}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        // Função para exibir estatísticas 
        public void ExibirEstatisticasAcao()
        {
            Console.Clear();
            Console.WriteLine("=== ESTATÍSTICAS NUTRICIONAIS ===\n");

            var (contagemSaudavel, contagemUltraprocessado, totalDias, contagensDiarias) = _repositorio.ObterEstatisticas();
            int totalRegistros = contagemSaudavel + contagemUltraprocessado;

            if (totalRegistros == 0)
            {
                Console.WriteLine("Nenhum dado foi registrado para gerar estatísticas.");
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }

            // Consumo diário
            Console.WriteLine("Consumo diário:\n");
            foreach (var contagem in contagensDiarias)
            {
                Console.WriteLine($"{contagem.data:dd/MM/yyyy} : {contagem.contagem} alimentos");
            }

            // Porcentagem alimentos saudáveis x ultraprocessados
            Console.WriteLine("\nDistribuição geral de alimentos:\n");
            double percSaudavel = (contagemSaudavel / (double)totalRegistros) * 100;
            double percIndustrializado = (contagemUltraprocessado / (double)totalRegistros) * 100;

            Console.WriteLine($"Saudáveis: {contagemSaudavel} ({percSaudavel:F1}%)");
            Console.WriteLine($"Ultraprocessados: {contagemUltraprocessado} ({percIndustrializado:F1}%)");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
