using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLibrary;

namespace WebNotes.Models
{
    public class EditViewModel
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public Status Status { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public string SecondName { get; set; }
    }
}