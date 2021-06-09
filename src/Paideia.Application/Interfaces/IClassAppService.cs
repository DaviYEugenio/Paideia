using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface IClassAppService
    {
        Task<IEnumerable<ClassViewModel>> Get();
        Task Save(ClassViewModel model);
        Task<ClassViewModel> GetById(Guid id);
        Task Update(ClassViewModel model);
        Task Remove(Guid id);
    }
}
