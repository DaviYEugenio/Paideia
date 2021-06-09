using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface IDropoutsRepository
    {
        Task<IEnumerable<Dropouts>> Get();
        Task Save(Dropouts candidate);
        Task<Dropouts> GetById(Guid id);
        Task<Dropouts> GetByName(string name);
        Task<Dropouts> Update(Dropouts training);
        Task Remove(Guid id);
    }
}
