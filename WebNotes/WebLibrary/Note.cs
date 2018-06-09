using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
   public class Note
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateChenged { get; set; }
        public virtual User Autor { get; set; }
        public virtual File File { get; set; }

    }
}
