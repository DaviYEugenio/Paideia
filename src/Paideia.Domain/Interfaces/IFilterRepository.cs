using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface IFilterRepository
    {
        Task<IEnumerable<CandidateStatus>> GetByIdStatus(string id);        
        Task<IEnumerable<CandidateStatus>> GetCandidateStatus();
    }
}
