using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface IDisciplineRepository
    {
        Task<IEnumerable<Discipline>> Get();
        Task Save(Discipline model);
        Task<IEnumerable<Discipline>> GetByTrainingModelId(Guid trainingModelId);
        Task<Discipline> GetById(Guid id);
        Task<Discipline> Update(Discipline model);
        Task Remove(Guid id);
    }
}
