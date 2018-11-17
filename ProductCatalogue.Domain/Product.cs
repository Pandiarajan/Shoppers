namespace ProductCatalogue.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }        
        public Unit Unit { get; set; }

        public Product()
        {

        }

        public Product(string name, string description, 
            int quantity, Category category, Unit unit)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Category = category;
            Unit = unit;
            UnitId = unit.Id;
            CategoryId = category.Id;
        }
    }
}
