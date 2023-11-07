using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class Meal
    {
        public EProductType ProductType { get; set; }
        public float Price { get; set; }

        public Meal(EProductType ProductType, float Price)
        {
            this.ProductType = ProductType;
            this.Price = Price;
        }
    }
}
