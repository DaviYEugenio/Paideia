using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Paideia.Application.Interfaces
{
    public interface ITraningAppService
    {
      Task<IEnumerable<TrainingViewModel>> GetAll();
      Task<TrainingViewModel> GetById(Guid id);
      Task Update(TrainingViewModel training);
      Task Add(TrainingViewModel training);
      Task Remove(Guid id);     
    }
}
