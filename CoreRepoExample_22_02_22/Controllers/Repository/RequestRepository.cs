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
    }
}
