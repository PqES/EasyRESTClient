namespace MsProduct.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public double Value { get; set; }

        public Product(int Id, string Name, string Description, int Number, double Value)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Number = Number;
            this.Value = Value;
        }

        public Product(string Name, string Description, int Number, double Value)
        {
            this.Name = Name;
            this.Description = Description;
            this.Number = Number;
            this.Value = Value;
        }

        public Product() { }
    }
}
