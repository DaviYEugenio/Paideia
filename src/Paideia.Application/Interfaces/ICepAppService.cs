using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ICepAppService
    {
        Task<string> GetByCep(string cep);
    }
}
