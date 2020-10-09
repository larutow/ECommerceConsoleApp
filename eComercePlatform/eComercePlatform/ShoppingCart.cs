using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComercePlatform
{
    class ShoppingCart
    {
        //member variables (HAS)
        public List<Product> products;
        public double totalCostProducts;
        //constructor (SPAWNER/CREATOR)
        public ShoppingCart()
        {
            products = new List<Product>();
        }
        //member methods (CAN DO)
        public void cartSum()
        {
            //update total cost of products in cart using member variable
            totalCostProducts = 0;
            foreach (Product item in products)
            {
                totalCostProducts += item.price;
            }
            Console.WriteLine("Cart Subtotal = " + totalCostProducts);
        }
        public void removeProduct(Product currentProduct)
        {
            //reduce cost of products then remove product from list
            products.Remove(currentProduct);
            cartSum();

        }

        public void addProduct(Product currentProduct)
        {
            //add item to cart then update cartSum
            products.Add(currentProduct);
            cartSum();

        }

    }
}
