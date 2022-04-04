using System;
using System.Threading.Tasks;


namespace ProjAndreAirLines.Model
{
    public class Endereco
    {

        #region Propriedades
        public int Id { get; set; }
      //  [JsonProperty("pais")]
        public string? Pais { get; set; }
       // [JsonProperty("cep")]
        public string CEP { get; set; }
      //  [JsonProperty("bairro")]
        public string Bairro { get; set; }
       // [JsonProperty("localidade")]
        public string Cidade { get; set; }
       // [JsonProperty("uf")]
        public string Estado { get; set; }
      //  [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
      //  [JsonProperty("gia")]
        public int Numero { get; set; }
      //  [JsonProperty("complemento")]
        public string Complemento { get; set; }



        #endregion

       
    }
}
