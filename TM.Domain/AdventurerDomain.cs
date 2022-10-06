using TM.Models;

namespace TM.Domain
{
    public class AdventurerDomain
    {
        public OrientationEnum ChangeOrientation(OrientationEnum actualOrientation, MovementEnum movement)
        {
            OrientationEnum finalOrientation = actualOrientation;
            switch (movement)
            {
                case MovementEnum.D:
                    finalOrientation += 90;
                    break;
                case MovementEnum.G:
                    finalOrientation -= 90;
                    break;
                default: break;
            }
            if ((int)finalOrientation >= 360)
            {
                finalOrientation = 0;
            }
            return finalOrientation;
        }
        public string[,] Render(Adventurer adventurer, string[,] actualRenderedMap)
        {
            string[,] finalRenderedMap = actualRenderedMap;
            Coordinates currentAdventurerCoordinates = adventurer.Coordinates;
            foreach (char movement in adventurer.Movements)
            {
                switch (movement)
                {
                    case 'A':
                        switch (adventurer.Orientation)
                        {
                            case OrientationEnum.N:
                                if (currentAdventurerCoordinates.PositionY > 0 && finalRenderedMap[currentAdventurerCoordinates.PositionY - 1, currentAdventurerCoordinates.PositionX] != "M")
                                {
                                    currentAdventurerCoordinates.PositionY -= 1;
                                }
                                break;
                            case OrientationEnum.S:
                                if (currentAdventurerCoordinates.PositionY < finalRenderedMap.GetLength(1) && finalRenderedMap[currentAdventurerCoordinates.PositionY + 1, currentAdventurerCoordinates.PositionX] != "M")
                                {
                                    currentAdventurerCoordinates.PositionY += 1;
                                }
                                break;
                            case OrientationEnum.E:
                                if (currentAdventurerCoordinates.PositionY > 0 && finalRenderedMap[currentAdventurerCoordinates.PositionY, currentAdventurerCoordinates.PositionX + 1] != "M")
                                {
                                    currentAdventurerCoordinates.PositionX += 1;
                                }
                                break;
                            case OrientationEnum.O:
                                if (currentAdventurerCoordinates.PositionX < finalRenderedMap.GetLength(0) && finalRenderedMap[currentAdventurerCoordinates.PositionY, currentAdventurerCoordinates.PositionX - 1] != "M")
                                {
                                    currentAdventurerCoordinates.PositionX -= 1;
                                }
                                break;
                            default: break;
                        }
                        break;
                    case 'G':
                    case 'D':
                        adventurer.Orientation = ChangeOrientation(adventurer.Orientation, (MovementEnum)Enum.Parse(typeof(MovementEnum),movement.ToString()));
                        break;
                    default: throw new NotImplementedException();
                }
            }
            finalRenderedMap[currentAdventurerCoordinates.PositionY, currentAdventurerCoordinates.PositionX] = "A";
            return finalRenderedMap;
        }

        public string[] Travel(string[] entries)
        {
            throw new NotImplementedException();
        }
    }
}