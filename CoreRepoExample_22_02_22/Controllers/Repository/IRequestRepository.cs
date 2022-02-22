using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public interface IRequestRepository
    {
        void Insert(Request entity);
        IEnumerable<Request> GetRequests();
        IQueryable<Request> GetRequestsAll();
        IEnumerable<Request> GetRequestByFilter(string name = null, string email = null, string tel = null, string mesaj = null);
        void Update(Request entity);
        void Delete(Request entity);
        Request GetById(int id);
    }

}
