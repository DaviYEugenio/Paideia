using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class LoginViewModel
    {
        
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }


        
        [Display(Name = "Email")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "NovaSenha")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        public string ConfirmPassword { get; set; }

        
        public string Token { get; set; }


        public string ReturnUrl { get; set; }
    }
}
