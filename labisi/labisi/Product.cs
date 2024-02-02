using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labisi
{
    internal class Product
    {
        public Product(string name, double price, DateTime expiredate)
        {
            _no++;
            this.No = _no;
            this.Name = name;
            this.Price = price;
            this.ExpireDate = expiredate;
        }
        public Product(string name,double price,double costprice,DateTime expiredate)
        {
            _no++;
            this.No = _no;
            this.Name = name;    
            this.Price = price;
            this.CostPrice = costprice;
            this.ExpireDate = expiredate;
        }
        
        static int _no;
        public int No;
        public string Name;
        public double Price;
        public double CostPrice;
        public DateTime ExpireDate;

        public override string ToString()
        {
            return  No + "." +Name + " - "+ Price + " man"+ "//" + ExpireDate.ToString("dd.MM.yyyy");
        }

    }
}
