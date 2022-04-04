using System;
using System.ComponentModel.DataAnnotations;

namespace ProjAndreAirLines.Model
{
    public class Passageiro
    {
        #region Propriedades
        [Key]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }

        #endregion

        public Passageiro()
        {

        }

        public Passageiro(string cPF, string nome, string telefone, DateTime dataNascimento, string email)
        {
            CPF = cPF;
            Nome = nome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Email = email;

        }

        public string ToString()
        {
            return "\n\n CPF: " + CPF + "\nNome: " + Nome + "\nTelefone : " + Telefone + "\nData Nascimento : " + DataNascimento + "\n Email : " + Email + "\n Endereco : " + Endereco.ToString();
        }
    }
}
