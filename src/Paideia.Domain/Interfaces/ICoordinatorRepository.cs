using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ICoordinatorRepository
    {
        Task<IEnumerable<Coordinator>> Get();
        Task Save(Coordinator coordinator);
        Task<Coordinator> GetById(Guid id);
        Task<Coordinator> Update(Coordinator coordinator);
        Task Remove(Guid id);
    }
}
