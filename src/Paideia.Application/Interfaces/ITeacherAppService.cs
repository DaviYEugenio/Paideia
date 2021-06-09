using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ITeacherAppService
    {
        Task<IEnumerable<TeacherViewModel>> Get();
        Task Save(TeacherViewModel model);
        Task<TeacherViewModel> GetById(Guid id);
        Task Update(TeacherViewModel model);
        Task Remove(Guid id);
    }
}
