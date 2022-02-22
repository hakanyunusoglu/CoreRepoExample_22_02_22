using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetById(int id);
        IQueryable<Course> GetCourseAll();
        void Insert(Course entity);
        IQueryable<Course> GetStatusCourses(bool status);
        IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null);
        void Update(Course entity);
        void Delete(Course entity);
    }
}
