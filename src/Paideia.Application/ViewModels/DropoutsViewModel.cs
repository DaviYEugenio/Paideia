using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Paideia.Application
{
    public class DropoutsViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Data de Rejeição")]
        public DateTime DateDropout { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("É da IBPV?")]
        public string IsFromIBPV { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("É pastor ou missionário?")]
        public string ShepherdOrMissionary { get; set; }       

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Motivo")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Data de inscrição")]
        public DateTime DateInscription { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Igreja")]
        public string Church { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Telefone")]
        public decimal Fone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Celular")]
        public decimal Cell { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Telefone comercial")]
        public decimal FoneComercial { get; set; }

        public string CandidateName { get; set; }
      
        public Guid CandidateId { get; set; }
    }
}
