using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Medicine
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Medicine(string name, int quantity, double price, string category, List<Ingredient> ingredients)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
            Ingredients = ingredients;
        }
    }
}
