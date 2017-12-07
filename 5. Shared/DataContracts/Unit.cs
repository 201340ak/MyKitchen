namespace MyKitchen.DataContracts
{
    public class Unit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public UnitType? Type { get; set; }
    }
}