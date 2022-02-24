using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepoExample_22_02_22.Controllers.Repository
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();
        Teacher GetById(int id);
        IQueryable<Teacher> GetTeacherAll();
        void Insert(Teacher entity);
        IEnumerable<Teacher> GetTeachersByFilter(string name = null, string surname = null);
        void Update(Teacher entity);
        void Delete(Teacher entity);
        IEnumerable<Teacher> GetAvailableTeachers();
        void Save();
    }
}
