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
                        entry = new Map() { EntryType ='C', Height = height, Width = width };
                    }
                    break;
                case "M":
                    if (entries.Length == 3 && int.TryParse(entries[1], out positionX) && int.TryParse(entries[2], out positionY))
                    {
                        entry = new Mountain() { EntryType = 'M', Coordinates = new Coordinates() { PositionX = positionX, PositionY = positionY } };
                    }
                    break;
                case "T":
                    if (entries.Length == 4 && int.TryParse(entries[1], out positionX) && int.TryParse(entries[2], out positionY) && int.TryParse(entries[3], out stock))
                    {
                        entry = new Treasure() { EntryType = 'T', Coordinates = new Coordinates() { PositionX = positionX, PositionY = positionY }, Stock = stock };
                    }
                    break;
                case "A":
                    if (entries.Length == 6 && int.TryParse(entries[2], out positionX) && int.TryParse(entries[3], out positionY))
                    {
                        entry = new Adventurer() { EntryType = 'A', Name = entries[1], Coordinates = new Coordinates() { PositionX = positionX, PositionY = positionY }, Orientation = (OrientationEnum)Enum.Parse(typeof(OrientationEnum),entries[4]), Movements = entries[5] };
                    }
                    break;
                default: throw new NotImplementedException();
            }
            return entry;
        }

        public string[,] Render(string[] entries)
        {
            List<Entry> entriesList = new List<Entry>();
            foreach (string entry in entries)
            {
                entriesList.Add(Parse(entry));
            }
            if (entriesList.First() is not Map)
                throw new NotImplementedException();
            Map map = (Map)entriesList.First();
            string[,] result = new string[map.Height, map.Width];
            foreach (Entry entry in entriesList)
            {
                switch (entry)
                {
                    case Mountain m:
                        result[m.Coordinates.PositionY, m.Coordinates.PositionX] = "M";
                        break;
                    case Treasure t:
                        result[t.Coordinates.PositionY, t.Coordinates.PositionX] = $"T;{t.Stock}";
                        break;
                    case Adventurer t:
                        AdventurerDomain adventurerDomain = new AdventurerDomain();
                        result = adventurerDomain.Render(t, result);
                        break;
                    default: break;
                }
            }
            return result;
        }
    }
}