using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class TeacherViewModel
    {
        
        public Guid TrainingModelId { get; set; }
       
        public Guid TrainingId { get; set; }

        public List<Guid> DisciplineIds { get; set; }
       
        public String Id { get; set; }
       
        [DisplayName("Discipline")]
        public string Name { get; set; }
        
        [DisplayName("Apresentation")]
        public string Apresentation { get; set; } 
        public List<TeacherDisciplinesViewModel> Disciplines { get; set; }    }

    public class TeacherDisciplinesViewModel
    {
        public string DisciplineName { get; set; }
        public string TrainingName { get; set; }
        public string TrainingModelName { get; set; }
        public Guid DisciplineId { get; set; }

    }
}
