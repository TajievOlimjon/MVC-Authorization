namespace WebAvtorize.Areas.Admin.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
       

    }
}
