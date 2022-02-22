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
    }
}
