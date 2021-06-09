using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface IDisciplineAppService
    {
        Task<IEnumerable<DisciplineViewModel>> GetByTrainingModelId(Guid trainingModelId);
        Task<IEnumerable<DisciplineViewModel>> Get();
        Task Save(DisciplineViewModel model);
        Task<DisciplineViewModel> GetById(Guid id);
        Task Update(DisciplineViewModel model);
        Task Remove(Guid id);
    }
}
