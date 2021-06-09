using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Dropouts
    {
        public Guid Id { get; set; }

        public Guid CandidateId { get; set; }

        public string Name { get; set; }
        
        public string Reason { get; set; }

        public string IsFromIBPV { get; set; }

        public string ShepherdOrMissionary { get; set; }

        public string SpouseTraining { get; set; }

        public DateTime DateInscription { get; set; }

        public DateTime DateDropout { get; set; }

        public string Church { get; set; }

        public string Email { get; set; }

        public decimal Fone { get; set; }

        public decimal Cell { get; set; }

        public decimal FoneComercial { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }



    }
}
