using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labisi
{
    internal class Store
    {
        public List<Product> Products;

        public List<Product> ApplyDiscount(List<Product> Products)
        {
            var toDiscount = Products.FindAll(x=> (x.ExpireDate.Date.Day - DateTime.Now.Day) == 3);
            if (toDiscount.Count == 0) Console.WriteLine("No products with 3 days left");
            toDiscount.ForEach(x => x.Price *= 0.8);
            return toDiscount;
        }
        public double TotalProfits(List<Product> Products)
        {
            double totalProfits = 0;
            foreach (var product in Products)
            {
                totalProfits += product.Price -  product.CostPrice;
            }
            return totalProfits;
        }
    }
}
