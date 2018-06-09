using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLibrary;

namespace WebNotes.Models
{
    public class NotesListViewModel
    {
       public IList<Note> Notes { get; set; }
        public NotesListViewModel()
        {
            Notes = new List<Note>();
        }
       

       
    }
}