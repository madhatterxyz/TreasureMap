using TM.Domain;
using TM.Models;

namespace TM.Tests
{
    public class AdventurerTests
    {
        [Fact]
        public void Adventurer_CantCrossOverMountain()
        {
            //Arrange
            EntryDomain entryDomain = new EntryDomain();
            string[,] expectedResult = new string[,]
            {
                {null,null,null },
                {null,null,null },
                {"M",null,null },
                {"A",null,null }
            };
            string[] entries = new string[]
            {
                "C - 3 - 4",
                "M - 0 - 2",
                "A - Indiana - 1 - 1 - S - AADADA"
            };
            //Act
            var actualResult = entryDomain.Render(entries);
            //Assert
            Assert.Equal(expectedResult,actualResult);
        }

        [Fact]
        public void OrientationSouth_Becomes_OrientationNorth()
        {
            //Arrange
            AdventurerDomain domain = new AdventurerDomain();
            //Act
            var orientation1 = domain.ChangeOrientation(OrientationEnum.S,MovementEnum.D);
            var orientation2 = domain.ChangeOrientation(orientation1, MovementEnum.D);
            //Assert
            Assert.Equal(OrientationEnum.N, orientation2);
        }
        [Fact]
        public void Adventurer_Can_Collect_Treasures()
        {
            //Arrange
            AdventurerDomain domain = new AdventurerDomain();

            string[] expectedResult = new string[]
            {
                "C - 3 - 4",
                "M - 1 - 0",
                "M - 2 - 1",
                "T - 1 - 3 - 2",
                "A - Lara - 0 - 3 - S - 3"
            };
            string[] entries = new string[]
            {
                "C - 3 - 4",
                "M - 1 - 0",
                "M - 2 - 1",
                "T - 0 - 3 - 2",
                "T - 1 - 3 - 3",
                "A - Lara - 1 - 1 - S - AADADAGGA"
            };
            //Act
            string[] actualResult = domain.Travel(entries);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}