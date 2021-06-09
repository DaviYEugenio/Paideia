using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ITeacherDisciplinesAppService
    {
        Task Save(TeacherViewModel model, Guid id);
        Task Remove(Guid id);
        Task<IEnumerable<TeacherDisciplinesViewModel>> GetByTeacherId(Guid teacherId);
    }
}
