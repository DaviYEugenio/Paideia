using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Paideia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Infra.Data.Repository
{       
    public class UserRepository : IUserRepository
    {
        
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;        
        public UserRepository(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;            
        }
        public async Task<Guid> GetById(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return new Guid(user.Id);
        }
    }
}
