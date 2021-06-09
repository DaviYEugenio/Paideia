using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Paideia.Application
{
    public class TrainingViewModel
    {
        
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Required]        
        public Guid CoordinatorId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Descricao")]
        public string Descripition { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Inicio")]
        public int StartDateYear { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Carga")]
        public int Workload { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Requisitos")]
        public string Requirements  { get; set; }

        public string CoordinatorName { get; set; }

    }
}

