using TM.Domain;
using TM.Models;

namespace TM.Tests
{
    public class EntryTests
    {
        [Fact]
        public void EntryParameters_ParseTo_Map()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            var actualResult = domain.Parse("C - 3 - 4");
            //Assert
            Assert.IsType<Map>(actualResult);
        }
        [Fact]
        public void MapWidthProperties_Equals_3()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Map actualResult = (Map)domain.Parse("C - 3 - 4");
            //Assert
            Assert.Equal(3, actualResult.Width);
        }
        [Fact]
        public void MapHeigthProperties_Equals_4()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Map actualResult = (Map)domain.Parse("C - 3 - 4");
            //Assert
            Assert.Equal(4, actualResult.Height);
        }

        [Fact]
        public void EntryParameters_ParseTo_Mountain()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            var actualResult = domain.Parse("M - 1 - 1");
            //Assert
            Assert.IsType<Mountain>(actualResult);
        }
        [Fact]
        public void MountainPositionX_Equals_1()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Mountain actualResult = (Mountain)domain.Parse("M - 1 - 1");
            //Assert
            Assert.Equal(1, actualResult.Coordinates.PositionX);
        }
        [Fact]
        public void MountainPositionY_Equals_1()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Mountain actualResult = (Mountain)domain.Parse("M - 1 - 1");
            //Assert
            Assert.Equal(1, actualResult.Coordinates.PositionY);
        }
        [Fact]
        public void EntryParameters_ParseTo_Treasure()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            var actualResult = domain.Parse("T - 0 - 3 - 2");
            //Assert
            Assert.IsType<Treasure>(actualResult);
        }
        [Fact]
        public void TreasurePositionX_Equals_0()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Treasure actualResult = (Treasure)domain.Parse("T - 0 - 3 - 2");
            //Assert
            Assert.Equal(0, actualResult.Coordinates.PositionX);
        }
        [Fact]
        public void TreasurePositionY_Equals_3()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Treasure actualResult = (Treasure)domain.Parse("T - 0 - 3 - 2");
            //Assert
            Assert.Equal(3, actualResult.Coordinates.PositionY);
        }
        [Fact]
        public void TreasureStock_Equals_2()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            //Act
            Treasure actualResult = (Treasure)domain.Parse("T - 0 - 3 - 2");
            //Assert
            Assert.Equal(2, actualResult.Stock);
        }

        [Fact]
        public void MultipleEntries_Returns_FilledMap()
        {
            //Arrange
            EntryDomain domain = new EntryDomain();
            string[] entries = new string[]
            {
                "C - 3 - 4",
                "M - 1 - 1",
                "M - 2 - 2",
                "T - 0 - 3 - 2",
                "T - 1 - 3 - 1"
            };
            string[,] expectedResult = new string[,]
            {
                {null,null,null },
                {null,"M",null },
                {null,null,"M" },
                {"T;2","T;1",null }
            };
            //Act
            string[,] actualResult = domain.Render(entries);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}