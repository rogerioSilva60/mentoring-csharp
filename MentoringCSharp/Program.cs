using MentoringCSharp.ClassAndMethods;
using System;
using System.Collections.Generic;

namespace MentoringCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Product rice = new Product() {
                Name = "Rice",
                Price =  4.99m,
                Discount = 0.10m
            };

            Product bean = new Product() {
                Name = "Bean",
                Price =  7.99m,
                Discount = 0.20m
            };

            List<ProductItems> items = new List<ProductItems>
            {
                new ProductItems()
                {
                    Amount = 2,
                    Product = rice
                },
                new ProductItems()
                {
                    Amount = 3,
                    Product = bean
                }
            };

            Console.WriteLine("Sale Description:");
            decimal totalValue = 0;
            items.ForEach(item =>
            {
                Console.WriteLine($"Description: {item.Product.Name}, Unit Price: {item.Product.Price}, " +
                    $"Total Amount: {item.Amount}, Discounted Full Price: {item.DiscountedFullPrice().ToString("N2")}");
                totalValue += item.DiscountedFullPrice();
            });
            Console.WriteLine($"Total to pay: {totalValue.ToString("N2")}");
            Console.ReadKey();
        }
    }
}
