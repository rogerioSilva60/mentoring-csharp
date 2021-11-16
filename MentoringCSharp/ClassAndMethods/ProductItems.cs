using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.ClassAndMethods
{
    public class ProductItems
    {
        public int Amount { get; set; }
        public Product Product { get; set; }

        public decimal TotalPriceWithoutDiscount()
        {
            return Product.Price * Amount;
        }

        public decimal DiscountedFullPrice()
        {
            decimal totalPrice = Product.Price * Amount;
            return totalPrice - (totalPrice * Product.Discount);
        }
    }
}
