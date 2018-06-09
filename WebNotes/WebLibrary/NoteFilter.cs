using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
    public class NoteFilter
    {
        public string Name { get; set; }

        public RangeDateTime DateCreated { get; set; }

        public NoteFilter()
        {
            DateCreated = new RangeDateTime();
        }
    }
}
