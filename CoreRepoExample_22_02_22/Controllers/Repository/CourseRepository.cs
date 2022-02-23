using CoreRepoExample_22_02_22.Models;
using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public class CourseRepository : ICourseRepository
    {
        DataContext db;
        private ITeacherRepository trep;
        public CourseRepository(DataContext _db, ITeacherRepository _trep)
        {
            db= _db;
            trep = _trep;
        }

        public IQueryable<Course> GetStatusCourses(bool status)
        {
            return db.Courses.ToList().Where(x => x.Aktif == status).AsQueryable();
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

        public IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null)
        {
            IQueryable<Course> query = db.Courses;
            

            if(name != null)
            {
                query = query.Where(x => x.Ad.Contains(name));
            }
            if(price != null)
            {
                query = query.Where(x => x.Fiyat >= price);
            }
            //if(Convert.ToBoolean(isActive) == false)
            //{
            //    query = query.Where(x=>x.Aktif == false);
            //}
            if(isActive =="on") //isActive == "on"
            {
                query = query.Where(x => x.Aktif == true); //true
            }
            return query.ToList();
           
           
        }

        public void Update(Course entity)
        {
            db.Courses.Update(entity);
            db.SaveChanges();
        }
        public void Delete(Course entity)
        {
            db.Courses.Remove(entity);
            db.SaveChanges();
        }
    }
}
