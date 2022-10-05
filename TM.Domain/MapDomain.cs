namespace TM.Domain
{
    public class MapDomain
    {
        public bool IsValid(string mapEntries)
        {
            string[] entries = mapEntries.Split(" - ");
            return entries.Length == 3 && entries[0].Equals("C") ;
        }
    }
}