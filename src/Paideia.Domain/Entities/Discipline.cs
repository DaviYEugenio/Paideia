using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Discipline
    {
        public Discipline()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string Requirements { get; set; }
        public virtual TrainingModel TrainingModel { get; set; }
        public virtual Training Training { get; set; }
        public Guid TrainingModelId { get; set; }        
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
