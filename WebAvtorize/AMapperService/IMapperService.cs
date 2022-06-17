using AutoMapper;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Areas.Admin.Models.ModelDTO;

namespace WebAvtorize.AMapperService
{
    public class IMapperService:Profile
    {
        public IMapperService()
        {
            CreateMap<StudentDTO,Student>();
            CreateMap<CourseDTO, Course>();
            CreateMap<TeacherDTO,Teacher>();
        }
    }
}
