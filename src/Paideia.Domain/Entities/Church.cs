using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Church
    {
        public Church()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Shepherd {get; set;}
        public string Street {get; set;}
        public int Number {get; set;}       
        public string Cep {get; set;}
        public string Neighborhood {get; set;}
        public string State { get; set;}
        public string City { get; set;}
        public Guid UserId { get; set;}
        public DateTime CreatedDate {get; set;}
        public DateTime? UpdatedDate {get; set;}
    }
}
