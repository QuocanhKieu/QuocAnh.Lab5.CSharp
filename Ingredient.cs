using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Ingredient
    {
        public string Name { get; set; }
        public double Amount { get; set; } // Đơn vị tính: miligram

        public Ingredient(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
