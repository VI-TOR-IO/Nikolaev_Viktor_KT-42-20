using _3_lab.Interfaces.CoursesInterfaces;
using _3_lab.Interfaces.StudentsInterfaces;

namespace _3_lab.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICoursesService, CourseService>();

            return services;
        }
    }
}