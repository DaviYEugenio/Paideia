using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> Get();
        Task Save(Candidate candidate);
        Task<Candidate> GetById(Guid id);
        Task<Candidate> Update(Candidate candidate);
        Task Remove(Guid id);
        Task<int> ValidEmail(string email);
        Task AddStatus(Guid id);
        Task<CandidateStatus> UpdateStatus(CandidateStatus model);
        Task<CandidateStatus> GetByIdCandidate(Guid id);
    }
}
