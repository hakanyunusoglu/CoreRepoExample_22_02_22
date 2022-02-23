using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoreRepoExample_22_02_22.Models.Data
{
    public class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            if(context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context is DataContext)
                {
                    DataContext _context = context as DataContext;
                    if(_context.Courses.Count() == 0)
                    {
                        //Ekleme işlemi yapacak
                        _context.Courses.AddRange(Courses);
                    }
                }
                context.SaveChanges();
            }
        }
        private static Course[] Courses = {new Course
        {
            Ad = "Html",
            Aciklama = "Html Hakkında",
            Fiyat = 145,
            Aktif = true,
             TeacherID = 2
        }, new Course
            {
               Ad = "Java",
               Aciklama = "Java Hakkında",
               Fiyat = 124,
               Aktif =false,
               TeacherID = 3
            } , new Course
            {
               Ad = "Css",
               Aciklama = "Css Hakkında",
               Fiyat = 180,
               Aktif =true,
               TeacherID = 1
            }, new Course
            {
               Ad = "React",
               Aciklama = "React Hakkında",
               Fiyat = 270,
               Aktif =false,
               TeacherID=3
            }
        };

    }
}
