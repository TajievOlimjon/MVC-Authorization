using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Areas.Admin.Models.ModelDTO;
using WebAvtorize.DataDB;

namespace WebAvtorize.Services
{
    public class CourseService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CourseService(DataContext _context,IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<CourseDTO>> GetCourses()
        {
            var list = await (
                    from c in context.Courses
                    orderby c descending
                    select new CourseDTO
                    {
                        Id=c.Id,
                        Name=c.Name
                    }).ToListAsync();
            if (list == null) return new  List<CourseDTO>();
            return list;
        }

        public async Task<CourseDTO> GetCourseByid( int Id)
        {
            var list = await (
                    from c in context.Courses
                    where c.Id==Id
                    select new CourseDTO
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).FirstOrDefaultAsync();
            if (list == null) return new CourseDTO();
            return list;
        }

        public async Task<int> Add(CourseDTO course)
        {
            var mapped = mapper.Map<Course>(course);
            await context.AddAsync(mapped);
            return await  context.SaveChangesAsync();
        }
         
        public async Task<int> Edit(CourseDTO course)
        {
            var c = await context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if (c == null) return 0;
            c.Name = course.Name;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(CourseDTO course)
        {
            var c = await context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if (c == null) return 0;
            context.Courses.Remove(c);
            return await context.SaveChangesAsync();
        }
    }
}
