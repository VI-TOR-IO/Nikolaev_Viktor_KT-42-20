using _3_lab.Models;

namespace Nikolaev_V_Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4220_True()
        {
            //arrange
            var testGroup = new Group

            {
                GroupName = "KT-42-20"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}