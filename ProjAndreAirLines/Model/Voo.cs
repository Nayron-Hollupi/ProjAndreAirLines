using System;

namespace ProjAndreAirLines.Model
{
    public class Voo
    {

        #region Propriedade
        public int Id { get; set; }
        public virtual Aeroporto Destino { get; set; }
        public virtual Aeroporto Origem { get; set; }
        public Aeronave Aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HoraDesembarque { get; set; }
        public string PassageiroCPF { get; set; }
        public  virtual Passageiro Passageiro { get; set; }


        #endregion
        public Voo()
        {
        }


        public Voo(int id, Aeroporto destino, Aeroporto origem, Aeronave aeronave, DateTime horarioEmbarque, DateTime horaDesembarque, Passageiro passageiro)
        {
            Id = id;
            Destino = destino;
            Origem = origem;
            Aeronave = aeronave;
            HorarioEmbarque = horarioEmbarque;
            HoraDesembarque = horaDesembarque;
            Passageiro = passageiro;
        }

        public override string ToString()
        {
            return "\n\n Destino: " + Destino.ToString() + "\nOrigem : " + Origem.ToString() + "\n" + Aeronave.ToString() + "\nHorario Embarque : " + HorarioEmbarque
                + "\nHora Desembarque: " + HoraDesembarque + "\n Passageiro: " + Passageiro.ToString();
        }
    }
}
