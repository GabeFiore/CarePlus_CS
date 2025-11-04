namespace ChallengeCarePlus.Modelos
{
    public class Refeicao
    {
        public DateTime Data { get; set; }
        public string TipoRefeicao { get; set; }
        public string NomeAlimento { get; set; }
        public string Categoria { get; set; }
        public double Quantidade { get; set; }
        public string Unidade { get; set; }

        public override string ToString()
        {
            return $"{TipoRefeicao} | {Data:dd/MM/yyyy} | {NomeAlimento} ({Categoria}) | {Quantidade} {Unidade}";
        }
    }
}
