namespace WebAvtorize.Areas.Admin.Models.ModelDTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public int Salary { get; set; }
        public int PositionId { get; set; }
    }
}
