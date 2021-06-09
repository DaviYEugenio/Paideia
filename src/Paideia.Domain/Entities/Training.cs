using System;
using System.ComponentModel.DataAnnotations;

namespace Paideia.Domain.Entities
{
    public class Training
    {
        public Training()
        {
            Id = Guid.NewGuid();            
        }

        public Guid Id { get; set; }        
        public string Name { get; set; }        
        public int StartDateYear { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public virtual Coordinator Coordinator { get; set; }
        public Guid CoordinatorId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Requirements { get; set; }
    }
}

