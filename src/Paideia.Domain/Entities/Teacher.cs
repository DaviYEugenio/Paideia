using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Apresentation { get; set; }  
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
