using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Areas.Admin.Models.ModelDTO;
using WebAvtorize.DataDB;

namespace WebAvtorize.Services
{
    public class StudentService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public StudentService(DataContext _context,IMapper _mapper )
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<StudentCourse>> GetStudents()
        {

            var list = await (from s in context.Students
                              orderby s descending
                              join c in context.Courses on s.CourseId equals c.Id
                              select new StudentCourse
                              {
                                  Id = s.Id,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  Age = s.Age,
                                  Birthday = s.Birthday,
                                  CourseId = c.Id,
                                  CourseName = c.Name
                              }).ToListAsync();
            if (list == null) return new List<StudentCourse>();
            return list;
        }

        public async Task<List<Student>> GetStudentAndCourses()
        {
            var list = await context.Students.Include(p=>p.Course).ToListAsync();
            return list;
        }

        public async Task<StudentDTO> GetStudentById(int Id)
        {
            var list = await (from s in context.Students
                              where s.Id == Id
                              select new StudentDTO
                              {
                                  Id = s.Id,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  Age = s.Age,
                                  Birthday = s.Birthday,
                                  CourseId = s.Id
                              }
                       ).FirstOrDefaultAsync();
            if (list == null) return new StudentDTO();
            return list;

        }

        public async Task<int> Added(StudentDTO student)
        {
            var mapped = mapper.Map<Student>(student);
            await context.Students.AddAsync(mapped);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Edit(StudentDTO student)
        {
           
            var mapped = mapper.Map<Student>(student);
            context.Students.Attach(mapped);
            context.Entry(mapped).State = EntityState.Modified;
            return await context.SaveChangesAsync(); 
        }
        public async Task<int> Delete(StudentDTO student)
        {
            var s = await context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (s == null) return 0;
            context.Students.Remove(s);
            return await context.SaveChangesAsync();

        }
    }
}
