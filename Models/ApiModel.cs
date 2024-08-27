using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CadastroFornecedores.Models
{
    public class ApiModel
    {
        private readonly HttpClient _httpClient;

        public ApiModel()
        {
            _httpClient = new HttpClient();
        }

        public async Task<EnderecoModel> BuscarEnderecoPorCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EnderecoModel>(jsonResponse);
            }
            return null;
        }
    }
    public class EnderecoModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        }
}