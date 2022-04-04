using System;

namespace ProjAndreAirLines.Model
{
    public class Passagem
    {
        #region Propriedades
        public int Id { get; set; }
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
        public decimal Valor { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataCadastro { get; set; }
        #endregion
    }
}
