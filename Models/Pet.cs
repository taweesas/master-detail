namespace TestMasterDetail.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
    }
}
