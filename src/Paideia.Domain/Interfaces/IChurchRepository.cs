using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface IChurchRepository
    {
        Task<IEnumerable<Church>> Get();
        Task Save(Church church);
        Task<Church> GetById(Guid id);
        Task<Church> Update(Church church);
        Task Remove(Guid id);
    }
}
