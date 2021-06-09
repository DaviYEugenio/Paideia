using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class ChurchViewModel
    {
        [Display(Name = "Id")]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [JsonProperty("nome")]
        public string Name { get; set; }

        [Display(Name = "Pastor")]
        [JsonProperty("pastor")]
        public string Shepherd { get; set; }

        [Display(Name = "Rua")]
        [JsonProperty("rua")]
        public string Street { get; set; }

        [Display(Name = "Número")]
        [JsonProperty("numero")]
        public int Number { get; set; }      

        [Display(Name = "Cep")]
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [Display(Name = "Bairro")]
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        [Display(Name = "Estado")]
        [JsonProperty("estado")]
        public string State { get; set; }


        [Display(Name = "Cidade")]
        [JsonProperty("cidade")]
        public string City { get; set; }


    }
}
