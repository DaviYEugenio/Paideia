using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paideia.Application
{
    public class CoordinatorViewModel
    {        
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Coordenador")]
        public string Name { get; set; }       
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
