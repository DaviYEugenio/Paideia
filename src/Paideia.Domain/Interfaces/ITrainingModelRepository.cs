using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
     public interface ITrainingModelRepository
    {
        
        Task<IEnumerable<TrainingModel>> Get();
        Task Save(TrainingModel model);
        Task<TrainingModel> GetById(Guid id);
        Task<IEnumerable<TrainingModel>> GetByTrainingId(Guid trainingId);
        Task<TrainingModel> Update(TrainingModel model);
        Task Remove(Guid id);
    }
}
