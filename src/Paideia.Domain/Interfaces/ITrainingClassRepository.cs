using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ITrainingClassRepository
    {
        Task<IEnumerable<TrainingClass>> Get();
        Task Save(TrainingClass model);
        Task<TrainingClass> GetById(Guid id);
        Task<TrainingClass> Update(TrainingClass model);        
        Task Remove(Guid id);
    }
}
