using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class CourseRepository : ICourseRepository
    {
        DataContext db;
        public CourseRepository(DataContext _db)
        {
            db= _db;

        }
        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Course> GetCourseAll()
        {
            return db.Courses.AsQueryable();
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        public void Insert(Course entity)
        {
            db.Courses.Add(entity);
            db.SaveChanges();
        }
    }
}
