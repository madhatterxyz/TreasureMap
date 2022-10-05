using TM.Models;

namespace TM.Domain
{
    public class EntryDomain
    {
        public Entry Parse(string entryString)
        {
            Entry entry = new Entry();
            int positionX, positionY, stock, height, width;
            string[] entries = entryString.Split(" - ");
            switch (entries[0])
            {
                case "C":
                    if (entries.Length == 3 && int.TryParse(entries[1], out width) && int.TryParse(entries[2], out height) && (width > height || width < height))
                    {
                        entry = new Map() { Height = height, Width = width };
                    }
                    break;
                case "M":
                    if (entries.Length == 3 && int.TryParse(entries[1], out positionX) && int.TryParse(entries[2], out positionY))
                    {
                        entry = new Mountain() { Coordinates = new Coordinates() { PositionX = positionX, PositionY = positionY } };
                    }
                    break;
                case "T":
                    if (entries.Length == 4 && int.TryParse(entries[1], out positionX) && int.TryParse(entries[2], out positionY) && int.TryParse(entries[3], out stock))
                    {
                        entry = new Treasure() { Coordinates = new Coordinates() { PositionX = positionX, PositionY = positionY }, Stock = stock };
                    }
                    break;
                default: throw new NotImplementedException();
            }
            return entry;
        }
    }
}