using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.Application.Services

{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserAppService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
        }       
            public async Task<bool> Register(AccountViewModel registroVM)
        {
            var user = new IdentityUser()
            {
                UserName = registroVM.UserName,
                Email = registroVM.Email
            };
            var result = await _userManager.CreateAsync(user, registroVM.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;            
        }
        public async Task Remove(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        public async Task<IEnumerable<AccountViewModel>> GetAll()
        {
            var users = _userManager.Users.ToList();
            var accounts = new List<AccountViewModel>();
            foreach(var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                var account = new AccountViewModel
                {
                    Id = user.Id,
                    Role = role.FirstOrDefault(),
                    Email = user.Email,
                    UserName = user.UserName
                };
                accounts.Add(account);
            }
            return accounts;

        }
        public async Task Update(AccountViewModel registroVM)
        {
            var user = await _userManager.FindByIdAsync(registroVM.Id);
            if (user != null) {
                user.UserName = registroVM.UserName;
                 await _userManager.UpdateAsync(user);                
            }
        }
        public async Task<AccountViewModel> GetById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var AccountViewModel = new AccountViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email                
            };
            return AccountViewModel;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
        

