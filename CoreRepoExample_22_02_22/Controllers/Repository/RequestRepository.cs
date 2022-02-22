using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private DataContext db;
        public RequestRepository(DataContext _db)
        {
            db= _db;
        }

        public void Delete(Request entity)
        {
            db.Requests.Remove(entity);
            db.SaveChanges();
        }

        public Request GetById(int id)
        {
            return db.Requests.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Request> GetRequestByFilter(string name = null, string email = null, string tel = null, string mesaj = null)
        {
            IQueryable<Request> query = db.Requests;
            if (name != null)
            {
                query = query.Where(x => x.Ad.Contains(name));
            }
            if (email != null)
            {
                query = query.Where(x => x.Email.Contains(email));
            }
            if (tel != null)
            {
                query = query.Where(x => x.Telefon == tel);
            }
            if (mesaj != null)
            {
                query = query.Where(x => x.Mesaj.Contains(mesaj));
            }
            return query.ToList();
        }

        public IEnumerable<Request> GetRequests()
        {
            return db.Requests.ToList();
        }

        public IQueryable<Request> GetRequestsAll()
        {
            return db.Requests.AsQueryable();
        }

        public void Insert(Request entity)
        {
            db.Requests.Add(entity);
            db.SaveChanges(); 
        }

        public void Update(Request entity)
        {
            db.Requests.Update(entity);
            db.SaveChanges();
        }
    }
}
