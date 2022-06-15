namespace WebAvtorize.Areas.Admin.Models.ModelDTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public int CourseId { get; set; }
    }

    public class StudentCourse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
    }
}
