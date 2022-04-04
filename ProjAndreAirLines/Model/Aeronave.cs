namespace ProjAndreAirLines.Model
{
    public class Aeronave
    {
        #region Propriedades
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }

        public Aeronave(string id, string nome, int capacidade)
        {
            Id = id;
            Nome = nome;
            Capacidade = capacidade;
        }
        #endregion

        public string ToString()
        {
            return "\nNome: " + Nome + "\nCapacidade : " + Capacidade; ;
        }
    }
}
