using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paideia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class LoginAppService : ILoginAppService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISendEmailAppService _sendEmailAppService;

        public LoginAppService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signManager,
            ISendEmailAppService sendEmailAppService)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _sendEmailAppService = sendEmailAppService;
        }
        public async Task<bool> Loggin(LoginViewModel loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        await _userManager.AddToRoleAsync(user, "Member");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return true;
                    }
                }
            }
            return false;
        }
        public async Task<bool> Recuperation(LoginViewModel loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var securityStamp = await _userManager.GetSecurityStampAsync(user);
                _sendEmailAppService.SendEmail(loginVM, securityStamp);
                return true;
            }
            return false;
        }
        public async Task<bool> ResetPassword(LoginViewModel loginVM, string email, string token)
        {            
            var user = await _userManager.FindByEmailAsync(email);            
            var securityStamp = await _userManager.GetSecurityStampAsync(user);
            if (token == securityStamp)
            {
                await _userManager.RemovePasswordAsync(user);
                var ok = await _userManager.AddPasswordAsync(user, loginVM.NewPassword);
                if (ok.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }        
    }
}
