using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNotes.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Логин")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}