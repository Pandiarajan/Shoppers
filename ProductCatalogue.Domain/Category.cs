using System.Collections.Generic;

namespace ProductCatalogue.Domain
{
    public class Category
    {
        public Category()
        {

        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
