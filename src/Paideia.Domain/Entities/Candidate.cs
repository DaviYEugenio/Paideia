using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }

        public Guid TrainingId { get; set; }       

        public virtual Training Training { get; set; }        

        public string Name { get; set; }
       
        public string IsFromIBPV { get; set; }
       
        public string ShepherdOrMissionary { get; set; }
       
        public string SpouseTraining { get; set; }
       
        public DateTime DateInscription { get; set; }
   
        public string Church { get; set; }
        
        public string Email { get; set; }
        
        public string Fone { get; set; }
        
        public string Cell { get; set; }
       
        public string FoneComercial { get; set; }        

    }
}