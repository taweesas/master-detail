namespace TestMasterDetail.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public School School { get; set; }
        public ICollection<Pet> Pet { get; set; }
    }
}
