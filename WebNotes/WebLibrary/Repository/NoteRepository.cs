using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using WebLibrary.Repository;

namespace WebLibrary.Repository
{
    [Repository]
    public class NoteRepository
    {
        
        private ISession session;
        public NoteRepository(ISession session)
        {
            this.session = session;
        }
        protected virtual void SetupFilter(ICriteria crit, NoteFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    crit.Add(Restrictions.Like("Name", filter.Name, MatchMode.Anywhere));
                }
                if (filter.DateCreated != null)
                {
                    if (filter.DateCreated.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("DateCreated", filter.DateCreated.From.Value));
                    }
                    if (filter.DateCreated.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("DateCreated", filter.DateCreated.To.Value));
                    }
                }
            }
        }
        protected virtual void SetFetchOptions(ICriteria crit, FetchOptions options)
        {
            if (!string.IsNullOrEmpty(options.SortExpression))
            {
                crit.AddOrder(options.SortDirection == SortDirection.Ascending ?
                    Order.Asc(options.SortExpression) :
                    Order.Desc(options.SortExpression));
            }
        }
        public IList<Note> GetUsersNotes(User user,  NoteFilter filter = null, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<Note>();
            crit.Add(Restrictions.Eq("Autor.Id", user.Id));
            SetupFilter(crit, filter);
            if (options != null)
            {
                SetFetchOptions(crit, options);
            }
            return crit.List<Note>();
            


        }
        public Note Load(long id)
        {
            return session.Load<Note>(id);
        }
        public void Save(Note note)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(note);
                tr.Commit();
            }
        }
    }
}
