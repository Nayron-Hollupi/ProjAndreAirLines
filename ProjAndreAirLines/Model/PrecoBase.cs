using System;
using System.ComponentModel.DataAnnotations;

namespace ProjAndreAirLines.Model
{
    public class PrecoBase
    {
        #region Propriedades
        public int Id { get; set; }
        [Key]
        public Aeroporto Origem { get; set; }
        [Key]
        public Aeroporto Destino { get; set; }
        [Key]
        public decimal Valor { get; set; }
        public double PromocaoPorcentagem { get; set; }
        public Classe Classe { get; set; }
        public DateTime Datainclusao{get; set;}
        #endregion
    }
}
