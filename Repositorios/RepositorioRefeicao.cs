using ChallengeCarePlus.Interfaces;
using ChallengeCarePlus.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCarePlus.Repositorios
{
    public class RepositorioRefeicao : IRepositorioRefeicao
    {
        private readonly List<Refeicao> _refeicoes = new List<Refeicao>();

        public void AdicionarRefeicao(Refeicao refeicao)
        {
            _refeicoes.Add(refeicao);
        }

        public List<Refeicao> ObterTodasRefeicoes()
        {
            return _refeicoes;
        }

        public (int contagemSaudavel, int contagemUltraprocessado, double totalDias, List<(DateTime data, int contagem)> contagensDiarias) ObterEstatisticas()
        {
            if (!_refeicoes.Any())
            {
                return (0, 0, 0, new List<(DateTime data, int contagem)>());
            }

            int contagemSaudavel = _refeicoes.Count(r => r.Categoria.Equals("Saudável", StringComparison.OrdinalIgnoreCase));
            int contagemUltraprocessado = _refeicoes.Count(r => r.Categoria.Equals("Ultraprocessado", StringComparison.OrdinalIgnoreCase));

            var contagensDiarias = _refeicoes
                .GroupBy(r => r.Data.Date)
                .Select(g => (data: g.Key, contagem: g.Count()))
                .OrderBy(x => x.data)
                .ToList();

            double totalDias = 0;            
            if (contagensDiarias.Any())
            {
                DateTime primeiraData = contagensDiarias.First().data;
                DateTime ultimaData = contagensDiarias.Last().data;
                totalDias = (ultimaData - primeiraData).TotalDays + 1;
            }

            return (contagemSaudavel, contagemUltraprocessado, totalDias, contagensDiarias);
        }
    }
}
