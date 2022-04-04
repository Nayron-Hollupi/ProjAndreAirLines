using System;
using System.Net.Http;
using System.Threading.Tasks;
using ProjAndreAirLines.Model;
using Newtonsoft.Json;


namespace ProjAndreAirLines.Server
{
    public class ApiCorreio
    {

        static readonly HttpClient endereco = new HttpClient();
  

        public static async Task<Endereco> CorreioApi(string cep)
        {

            try
            {
                HttpResponseMessage response = await ApiCorreio.endereco.GetAsync("https://viacep.com.br/ws/"+ cep +"/json/");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
             var end = JsonConvert.DeserializeObject<Endereco>(ender);

               return end;
            
            }
            catch (HttpRequestException e)
            {
                throw;
               
            }
        }
    }
}
