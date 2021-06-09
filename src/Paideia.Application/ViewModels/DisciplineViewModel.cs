using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class DisciplineViewModel     
    {
        [DisplayName("TrainingId")]
        public Guid TrainingModelId { get; set; }

        [DisplayName("TrainingId")]
        public Guid TrainingId { get; set; }


        [DisplayName("Id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Discipline")]
        public string Name { get; set; }


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
        public string TrainingModelName { get; set; }
    }
}
