using TM.Domain;

namespace TM.Tests
{
    public class MapTests
    {
        [Fact]
        public void MapParameters_IsValid_True()
        {
            //Arrange
            MapDomain domain = new MapDomain();
            //Act
            bool actualResult = domain.IsValid("C - 3 - 4");
            //Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void MountainParameters_IsValid_True()
        {
            //Arrange
            MapDomain domain = new MapDomain();
            //Act
            bool actualResult = domain.IsValid("M - 1 - 1");
            //Assert
            Assert.True(actualResult);
        }
    }
}