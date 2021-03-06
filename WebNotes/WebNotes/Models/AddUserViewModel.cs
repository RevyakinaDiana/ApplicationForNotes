﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebLibrary;

namespace WebNotes.Models
{
    public class AddUserViewModel
    {
        public User GetUser()
        {
            return new User
            {

                UserName = UserName,
                FirstName = FirstName,
                SecondName = SecondName,
                LastName = LastName,
                Email= Email,
                DateofBirth=DateOfBith,
                Permission = Permission.Common
            };
        }

        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Фамилия")]
        public string LastName { get; set; }


        [Display(Name = "Имя")]
        public string FirstName { get; set; }


        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        public string Email { get; set; }


        [Display(Name = "Дата рождения")]
        public DateTime DateOfBith { get; set; }


        public Permission Permission { get; set; }
    }
}