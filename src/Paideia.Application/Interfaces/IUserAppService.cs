using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface IUserAppService
    {
        Task Update(AccountViewModel registroVM);
        Task<IEnumerable<AccountViewModel>> GetAll();
        Task<AccountViewModel> GetById(string Id);
        Task<bool> Register(AccountViewModel registroVM);
        Task Remove(string Id);
        Task Logout();
    }
}
