using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class ClassViewModel
    {
        [DisplayName("TrainingId")]
        public Guid TrainingId { get; set; }


        [DisplayName("Id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Turma")]
        public string Class { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Descricao")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Inicio")]
        public int StartDateYear { get; set; }


        public string TrainingName { get; set; }
    }
}
