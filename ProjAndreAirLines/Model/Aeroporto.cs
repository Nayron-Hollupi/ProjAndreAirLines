using System;
using System.ComponentModel.DataAnnotations;
namespace ProjAndreAirLines.Model
{
    public class Aeroporto
    {


        #region Propriedades
        [Key]
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }


        #endregion

        public Aeroporto(string sigla, string nome, Endereco endereco)
        {
            Sigla = sigla;
            Nome = nome;
            Endereco = endereco;
        }

        public Aeroporto()
        {
          
        }

        public string ToString()
        {
            return "\n\n Sigla: " + Sigla + "\nNome: " + Nome + "\nEndereco : " + Endereco.ToString(); ;
        }

    }

  
}
