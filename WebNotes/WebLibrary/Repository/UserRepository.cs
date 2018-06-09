using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebLibrary.Repository
{
    [Repository]
    public  class UserRepository
    {
        private ISession session;
        public UserRepository(ISession session)
        {
            this.session = session;
        }
        public List<User> GetAll()
        {
            return session.CreateCriteria<User>().List<User>().ToList();
        }
        public void Save(User user)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(user);
                tr.Commit();
            }
        }
        public User Load(long id)
        {
            return session.Load<User>(id);
        }
        public User GetCurrentUser(IPrincipal user = null)
        {
            user = user ?? HttpContext.Current.User;
            if (user == null || user.Identity == null)
            {
                return null;
            }
            var currentUserId = user.Identity.GetUserId();
            long userId;
            if (string.IsNullOrEmpty(currentUserId) || !long.TryParse(currentUserId, out userId))
            {
                return null;
            }
            return Load(userId);
        }
    }
}
