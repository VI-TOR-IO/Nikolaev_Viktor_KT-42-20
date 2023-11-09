using _3_lab.Database;
using _3_lab.Filters.CourseFilters;
using Microsoft.EntityFrameworkCore;
using _1_lab.Models;

namespace _3_lab.Interfaces.CoursesInterfaces
{
    public interface ICoursesService
    {
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken);
    }

    public class CourseService : ICoursesService
    {
        private readonly StudentDbContext _dbContext;
        public CourseService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken = default)
        {
            var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return courses;
        }
    }
}