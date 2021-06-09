using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Paideia.Application
{
    public class ModelViewModel
    {
        [DisplayName("TrainingId")]
        public Guid TrainingId { get; set; }

        [DisplayName("Id")]
        public Guid Id { get; set; }  
        
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Modulo")]
        public string Module { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Descricao")]        
        public string Description { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Carga horaria")]
        public int Workload { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Requisitos")]
        public string Requirements { get; set; }

        public string TrainingName { get; set; }       
    }
}

