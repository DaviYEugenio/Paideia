
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface IChurchAppService
    {
        Task<IEnumerable<ChurchViewModel>> Get();
        Task Save(ChurchViewModel church);
        Task<ChurchViewModel> GetById(Guid id);
        Task Update(ChurchViewModel church);
        Task Remove(Guid id);
    }
}
