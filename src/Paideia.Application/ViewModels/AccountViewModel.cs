using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Paideia.Application
{
    public class AccountViewModel
    {
        [DisplayName("Id")]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Required]        
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
        public string Role { get; set; }
    }
}