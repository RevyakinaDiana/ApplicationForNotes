using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLibrary;

namespace WebNotes.Models
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public UserListViewModel()
        {
            Users = new List<User>();
        }
    }
}