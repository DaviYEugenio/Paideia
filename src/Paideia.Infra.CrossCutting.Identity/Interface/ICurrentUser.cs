using System;
using System.Threading.Tasks;

namespace Paideia.Infra.CrossCutting.Identity.Interface
{
    public interface ICurrentUser
    {
        Task<Guid> GetCurrentId();
    }
}
