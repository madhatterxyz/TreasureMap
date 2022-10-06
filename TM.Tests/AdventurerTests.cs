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
    }
}