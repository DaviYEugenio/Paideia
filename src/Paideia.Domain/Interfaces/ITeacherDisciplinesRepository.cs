using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ITeacherDisciplinesRepository
    {
        Task Save(TeacherDisciplines model);
        Task Remove(Guid id);
        Task<IEnumerable<TeacherDisciplines>> GetByTeacherId(Guid id);       
    }
}
