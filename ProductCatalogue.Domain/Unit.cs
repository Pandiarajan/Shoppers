using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogue.Domain
{
    public class Unit
    {
        public static Unit Gram = new Unit(1, "Gram");
        public static Unit Descrete = new Unit(2, "Descrete");
        public static Unit MilliLiter = new Unit(3, "MilliLiter");
        private static List<Unit> Units = new List<Unit> { Gram, Descrete, MilliLiter };
        public Unit()
        {

        }
        public Unit(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

        public static Unit Get(string unit)
        {
            return Units.First(u => u.Description == unit);
        }
    }
}