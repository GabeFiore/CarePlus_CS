using ChallengeCarePlus.Modelos;
using System.Collections.Generic;

namespace ChallengeCarePlus.Interfaces
{
    public interface IRepositorioRefeicao
    {
        void AdicionarRefeicao(Refeicao refeicao);
        List<Refeicao> ObterTodasRefeicoes();
        (int contagemSaudavel, int contagemUltraprocessado, double totalDias, List<(DateTime data, int contagem)> contagensDiarias) ObterEstatisticas();
    }
}
