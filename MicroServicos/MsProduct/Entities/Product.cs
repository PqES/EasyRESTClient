namespace MsProduct.Entities
{
    public class Product
    {
        public string Id;
        public string Name;
        public string Description;
        public int Number;
        public double Value;

        public Product(string Id, string Name, string Description, int Number, double Value)
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
