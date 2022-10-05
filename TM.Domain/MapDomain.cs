namespace TM.Domain
{
    public class MapDomain
    {
        public bool IsValid(string mapEntries)
        {
            string[] entries = mapEntries.Split(" - ");
            switch (entries[0])
            {
                case "C":
                    if (entries.Length != 3 && (int.Parse(entries[1]) > int.Parse(entries[2]) || int.Parse(entries[1]) < int.Parse(entries[2])))
                    {
                        return true;
                    }
                    break;
                case "M":
                    if (entries.Length != 3 && (!int.TryParse(entries[1], out _) || !int.TryParse(entries[2], out _)))
                    {
                        return false;
                    }
                    break;
                case "T":
                    if (entries.Length != 4 && (!int.TryParse(entries[1], out _) || !int.TryParse(entries[2], out _) || !int.TryParse(entries[3], out _)))
                    {
                        return false;
                    }
                    break;
                default: return false;
            }
            return true;
        }
    }
}