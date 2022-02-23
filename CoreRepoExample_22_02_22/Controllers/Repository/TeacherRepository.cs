using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        DataContext db;
        public TeacherRepository(DataContext _db)
        {
            db = _db;

        }

        public void Delete(Teacher entity)
        {
            db.Teachers.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Teacher> GetAvailableTeachers()
        {
            return db.Teachers.Where(x=>x.Course.TeacherID != x.ID).ToList();
        }

        public Teacher GetById(int id)
        {
            IQueryable<Teacher> query = db.Teachers.Where(x => x.ID == id).Include(x=>x.Address);
           
            return query.FirstOrDefault(x=>x.ID == id);
        }

        public IQueryable<Teacher> GetTeacherAll()
        {
            return db.Teachers.AsQueryable();
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return db.Teachers.ToList();
        }

        public IEnumerable<Teacher> GetTeachersByFilter(string name = null, string surname = null)
        {
            IQueryable<Teacher> query = db.Teachers;


            if (name != null)
            {
                query = query.Where(x => x.Name.Contains(name));
            }
            if (surname != null)
            {
                query = query.Where(x => x.Surname.Contains(surname));
            }
            return query.Include(x => x.Address).ToList();
        }

        public void Insert(Teacher entity)
        {
            db.Teachers.Add(entity);
            db.Teachers.Where(x => x.ID == entity.ID).Include(x=>x.Address == entity.Address);
            db.SaveChanges();
        }

        public void Update(Teacher entity)
        {
            db.Teachers.Update(entity);
            db.SaveChanges();
        }
    }
}
