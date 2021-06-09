using System.Threading.Tasks;

namespace Paideia.Application.Interfaces
{
    public interface ISendEmailAppService
    {        
        void SendEmail(LoginViewModel loginVM, string token);
    }
}
