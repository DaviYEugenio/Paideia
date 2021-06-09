using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Coordinator
    {
        public Coordinator()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
