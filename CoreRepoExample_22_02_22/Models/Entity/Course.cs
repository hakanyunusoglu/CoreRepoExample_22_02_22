namespace CoreRepoExample_22_02_22.Models.Entity
{
    public class Course
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public bool Aktif { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

    }
}
