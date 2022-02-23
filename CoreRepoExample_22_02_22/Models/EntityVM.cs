using CoreRepoExample_22_02_22.Models.Entity;
using System.Collections.Generic;

namespace CoreRepoExample_22_02_22.Models
{
    public class EntityVM
    {
        public Teacher Teachers { get; set; }
        public ICollection<Teacher> tList { get; set; }
        public Address Addresses { get; set; }
        public ICollection<Address> aList { get; set; }
        public Course Courses { get; set; }
        public ICollection<Course> cList { get; set; }
    }
}
