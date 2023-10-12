using Microsoft.EntityFrameworkCore;
using _3_lab.Database;
using _3_lab.Interfaces.StudentsInterfaces;
using _3_lab.Models;
using _3_lab.Filters.StudentFilters;

namespace Nikolaev_V_Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-41-20"
                },
                new Group
                {
                    GroupName = "KT-42-20"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Mironov",
                    LastName = "Galka",
                    MiddleName = "Yletel",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "Gryzdev",
                    LastName = "Boris",
                    MiddleName = "Proigral",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "Shashkin",
                    LastName = "Shachmat",
                    MiddleName = "Pobedil",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new StudentGroupFilter
            {
                GroupName = "KT-42-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}
