using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance5.Entities
{
    internal class Product
    {
        public string Name { get; set; }
        public double price { get; set; }

        public Product()
        {

        }

        public Product(string name, double price)
        {
            Name = name;
            this.price = price;
        }

        public virtual string PriceTag()
        {
            return Name
                + "$ "
                + price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
