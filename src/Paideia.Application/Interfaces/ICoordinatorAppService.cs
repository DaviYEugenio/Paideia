using Paideia.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ICoordinatorAppService
    {
        Task<IEnumerable<CoordinatorViewModel>> Get();
        Task Save(CoordinatorViewModel coordinator);
        Task<CoordinatorViewModel> GetById(Guid id);
        Task Update(CoordinatorViewModel coordinator);
        Task Remove(Guid id);
    }
}
