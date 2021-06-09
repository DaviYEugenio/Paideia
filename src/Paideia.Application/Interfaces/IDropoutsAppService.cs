using Paideia.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface IDropoutsAppService
    {
        Task<IEnumerable<DropoutsViewModel>> Get();
        Task Save(DropoutsViewModel candidate);
        Task<DropoutsViewModel> GetById(Guid id);
        Task<DropoutsViewModel> GetByName(string name);
        Task Update(DropoutsViewModel candidate);
        Task Remove(Guid id);
    }
}
