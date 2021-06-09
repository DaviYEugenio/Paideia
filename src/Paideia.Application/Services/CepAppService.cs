using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class CepAppService : ICepAppService
    {
        public Task<string> GetByCep(string cep)
        {
            HttpClient cliente = new HttpClient();

            var resultado = cliente.GetAsync($"http://viacep.com.br/ws/{cep}/json/").Result;
            if (resultado.IsSuccessStatusCode)
            {
                var conteudo = resultado.Content;
                var resposta = conteudo.ReadAsStringAsync().Result;
                return Task.FromResult(resposta);
            }
            return Task.FromResult("Erro");
        }
    }
}

