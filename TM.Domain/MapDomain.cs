namespace TM.Domain
{
    public class MapDomain
    {
        public bool IsValid(string mapEntries)
        {
            string[] entries = mapEntries.Split(" - ");
            return entries.Length == 3 && (entries[0].Equals("C") || entries[0].Equals("M")) && 
                (int.Parse(entries[1]) > int.Parse(entries[2]) || int.Parse(entries[1]) < int.Parse(entries[2])) ;
        }
    }
}