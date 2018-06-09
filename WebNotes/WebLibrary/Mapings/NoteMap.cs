using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary.Mapings
{
    public class NoteMap: ClassMap<Note>
    {
        public NoteMap()
        {
            Id(n => n.Id).GeneratedBy.Identity();
            Map(n => n.Name).Length(50);
            Map(n => n.Text).Length(100);
            Map(n => n.DateCreated);
            Map(n => n.DateChenged);
            References(n => n.Autor);
            References(n => n.File);
        }
    }
}
