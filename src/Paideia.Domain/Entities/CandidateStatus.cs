using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Domain.Entities
{
    public class CandidateStatus
    {

        public CandidateStatus()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Guid StatusId { get; set; }
        public virtual Status Status { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
