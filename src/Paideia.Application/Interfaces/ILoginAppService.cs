using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<bool> Recuperation(LoginViewModel loginVM);
        Task<bool> Loggin(LoginViewModel loginVM);        
        Task<bool> ResetPassword(LoginViewModel loginVM, string token, string email);       
    }
}
