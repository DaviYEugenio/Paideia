using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get();
        Task Save(Teacher model);
        Task<Teacher> GetById(Guid id);
        Task<Teacher> Update(Teacher model);
        Task Remove(Guid id);
    }
}
