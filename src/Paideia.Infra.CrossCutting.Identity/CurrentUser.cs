using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity.Interface;
using System;
using System.Threading.Tasks;

namespace Paideia.Infra.CrossCutting.Identity
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpcontextaccessor;
        public CurrentUser(IHttpContextAccessor httpcontextaccessor, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _httpcontextaccessor = httpcontextaccessor;
        }
        public async Task<Guid> GetCurrentId()
        {
            var username = _httpcontextaccessor.HttpContext.User.Identity.Name;
            var result = await _userRepository.GetById(username);
            return result;
        }
    }
}
