using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary.Repository
{
    [Repository]
    public class FileRepository
    {
        protected ISession session;
        public FileRepository(ISession session)   
        {
            this.session = session;
        }
        public void Save(File file)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(file);
                tr.Commit();
            }
        }
    }
}
