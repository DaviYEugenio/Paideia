using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Status
    {
        public Status()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
