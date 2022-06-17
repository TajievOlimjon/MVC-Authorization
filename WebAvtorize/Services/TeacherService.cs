using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Areas.Admin.Models.ModelDTO;
using WebAvtorize.DataDB;

namespace WebAvtorize.Services
{
    public class TeacherService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public TeacherService(DataContext _context,IMapper _mapper)
        {
            context = _context;
            this.mapper = _mapper;
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            return await context.Teachers.Include(p => p.Position).ToListAsync();
        }

        public async Task<TeacherDTO> GetTeacherById(int Id)
        {
            var teacher = await (from t in context.Teachers
                              where t.Id==Id
                              select new TeacherDTO
                              {
                                  Id=t.Id,
                                  FirstName=t.FirstName,
                                  LastName=t.LastName,
                                  Age=t.Age,
                                  Email=t.Email,
                                  Image=t.Image,
                                  Salary=t.Salary,
                                  PositionId=t.PositionId                                  
                              }).FirstOrDefaultAsync();
            if (teacher == null) return new TeacherDTO();
            return teacher;
        }

        public async Task<int> Insert(TeacherDTO teacher)
        {
            var mapped = mapper.Map<Teacher>(teacher);
            await context.Teachers.AddAsync(mapped);
            return await context.SaveChangesAsync();
        }
    }
}
