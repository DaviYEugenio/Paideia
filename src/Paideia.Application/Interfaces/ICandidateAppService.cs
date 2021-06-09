using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ICandidateAppService
    {        
        Task<IEnumerable<CandidateViewModel>> GetByIdStatus(string id);
        Task<bool> Save(CandidateViewModel candidate);
        Task<CandidateViewModel> GetById(Guid id);
        Task Update(CandidateViewModel candidate); 
        Task UpdateStatus(Guid id);         
        Task Remove(Guid id);
        
    }
}
