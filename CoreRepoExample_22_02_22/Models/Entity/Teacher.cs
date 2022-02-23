namespace CoreRepoExample_22_02_22.Models.Entity
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public Course Course { get; set; }
    }
}
