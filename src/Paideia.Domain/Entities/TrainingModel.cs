using System;
using System.ComponentModel.DataAnnotations;

namespace Paideia.Domain.Entities
{
    public class TrainingModel
    {
            public TrainingModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }         
        public string Module { get; set; }
        public string Description { get; set; }
        public int Workload { get; set; }
        public string Requirements { get; set; }
        public virtual Training Training { get; set; }
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}