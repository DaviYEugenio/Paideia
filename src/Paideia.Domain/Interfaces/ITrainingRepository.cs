using Paideia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface ITrainingRepository 
    {   
        Task<IEnumerable<Training>> GetAll();
        Task<Training> GetById(Guid id);
        Task<Training> Update(Training training);
        Task Add(Training training);
        Task Remove(Guid id);
        
    }
}
