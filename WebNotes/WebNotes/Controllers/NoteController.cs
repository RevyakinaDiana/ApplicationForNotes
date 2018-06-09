using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary;
using WebLibrary.Repository;
using WebLibrary.Utils;
using WebNotes.Models;

namespace WebNotes.Controllers
{
    public class NoteController : BaseController
    {
        
        // GET: Note
        private NoteRepository noteRepository;
        public NoteController(NoteRepository noteRepository, UserRepository userRepository):base(userRepository)
        {
            this.noteRepository = noteRepository;
           
        }

        public ActionResult ShowNotes(User user, NoteFilter filter, FetchOptions options)
        {

            var model = new NotesListViewModel
            {
                Notes = noteRepository.GetUsersNotes(CurrentUser, filter, options)
            };

            return View(model);

        }
        public ActionResult TextNote(long id)
        {
            var n = noteRepository.Load(id);
            return View(new AddNoteViewModel
            {Id=n.Id,
                Name = n.Name,
                Text = n.Text,
                DateCreated  = n.DateCreated,
                DateChenged = n.DateChenged


            });
            return View();
        }
        public ActionResult CreateNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNote(AddNoteViewModel model)
        {
           
            Note note = new Note
            {
                Name=model.Name,
                Text=model.Text,
                Autor = CurrentUser,
                DateCreated = DateTime.Now,
                DateChenged = DateTime.Now,
                File = new File
                {

                    Name = model.File.FileName,
                    Content = model.File.InputStream.ToByteArray()
                }
                

            };
            
            
            noteRepository.Save(note);
            
            return RedirectToAction("ShowNotes", "Note");
        }
        [HttpPost]
        public ActionResult Change(AddNoteViewModel model)
        {

            var n = noteRepository.Load(model.Id);

           // n.Id = model.Id;
            n.Name = model.Name;
            n.Text = model.Text;
            n.DateChenged = DateTime.Now;
            
            noteRepository.Save(n);
            return RedirectToAction("ShowNotes", "Note");
        }
        public ActionResult Change(long id)
        {
            var note = noteRepository.Load(id);
            return View(new AddNoteViewModel
            {
                Id = note.Id,
                Name = note.Name,
                Text = note.Text,
                
            });
        }
    }
}