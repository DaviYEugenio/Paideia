using System;
using Microsoft.AspNet.Identity;

namespace Paideia.Domain.Entities
{
    public class TrainingClass
    {
        public TrainingClass()
        {
            Id = Guid.NewGuid();            
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartOfYear { get; set; }            
        public virtual Training Training { get; set; }
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}



       


