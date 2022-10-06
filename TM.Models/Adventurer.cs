namespace TM.Models
{
    public class Adventurer : Entry
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public OrientationEnum Orientation { get; set; }
        public string Movements { get; set; }
        public int NbTreasureFound { get; set; }
    }
}