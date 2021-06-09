using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class TeacherDisciplines
    {
        public TeacherDisciplines()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Teacher Teacher { get; set; }        
    }
}
