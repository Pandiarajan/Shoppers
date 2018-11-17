namespace ProductCatalogue.DataContract
{
    public class ProductContract
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Unit Unit { get; set; }
        public int Quantity { get; set; }
    }
}
