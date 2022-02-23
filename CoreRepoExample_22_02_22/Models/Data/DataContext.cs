using CoreRepoExample_22_02_22.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreRepoExample_22_02_22.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasOne(x => x.Teacher).WithOne(x => x.Course).HasForeignKey<Course>(x=>x.TeacherID);

        }
    }
}
