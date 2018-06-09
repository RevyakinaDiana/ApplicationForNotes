using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebLibrary;

namespace WebNotes.Models
{
    public class AddNoteViewModel
    {
       
        public long Id { get; set; }

        [Display(Name = "Название заметки")]
        public string Name { get; set; }

       
        [Display(Name = "Текст заметки")]
        public string Text { get; set; }

        public User Autor { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }


        [Display(Name = "Дата изменения")]
        public DateTime DateChenged { get; set; }

        [Display(Name = "Файл")]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}