using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class CandidateViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }
        
        public Guid TrainingId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        public string TrainingName { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("É da IBPV?")]
        public string IsFromIBPV { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("É pastor ou missionário?")]
        public string ShepherdOrMissionary { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Cônjuge fará o terinamento?")]
        public string SpouseTraining { get; set; }

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
        public string Fone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Celular")]
        public string Cell { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Telefone comercial")]
        public string FoneComercial { get; set; }

        public string Status { get; set; }
    }
}
