using _1_lab.Models;
using _3_lab.Database;
using _3_lab.Filters.CourseFilters;
using _3_lab.Filters.StudentFilters;
using _3_lab.Interfaces.CoursesInterfaces;
using _3_lab.Interfaces.StudentsInterfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;
using _3_lab.Models;

namespace Test
{
    public class CourseTest
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public CourseTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetCoursesByGroupAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var courseService = new CourseService(ctx);

            var groups = new List<Group>
            {
                new Group
                {
                    GroupId =100,
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupId =200,
                    GroupName = "KT-41-20"
                }
            };

            await ctx.Set<Group>().AddRangeAsync(groups);
            await ctx.SaveChangesAsync();

            var course = new List<Course>
            {
                new Course
                {
                    CourseId = 1,
                    Title = "PISK",
                    GroupId = 200
                },
                new Course
                {
                    CourseId = 2,
                    Title = "PP",
                    GroupId = 200
                }             
            };
            await ctx.Set<Course>().AddRangeAsync(course);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new CourseFilter
            {
                GroupName = "KT-31-20"
            };
            var Result = await courseService.GetCoursesByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Empty(Result);
        }
    }
}
