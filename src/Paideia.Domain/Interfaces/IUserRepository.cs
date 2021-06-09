using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> GetById(string userName);
    }
}
