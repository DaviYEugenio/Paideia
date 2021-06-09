using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
   public interface IModelAppService
    {
        Task<IEnumerable<ModelViewModel>> GetByTrainingId(Guid trainingId);
        Task<IEnumerable<ModelViewModel>> Get();
        Task Save(ModelViewModel model);
        Task<ModelViewModel> GetById(Guid id);
        Task Update(ModelViewModel model);       
        Task Remove(Guid id);
    }
}
