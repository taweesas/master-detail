namespace TestMasterDetail.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
