using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComercePlatform
{
    class Consumer
    {
        //member variables (HAS)
        public string firstName;
        public string lastName;
        public ShoppingCart shoppingCart;
        //constructor (SPAWNER/CREATOR)
        public Consumer()
        {
            shoppingCart = new ShoppingCart();
        }

        //member methods (CAN DO)
        public void setFirstName(string firstName, string lastName)
        {
            this.firstName = firstName;
            
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;

        }

        public Product searchProduct(string productName, List<Product> inventory)
        {
            Product foundProduct = new Product(0, "No Product Found", "Error", 0.00);
            bool isProductInInventory = false;
            foreach (Product product in inventory)
            {
                if (productName == product.name)
                {
                    isProductInInventory = true;
                    foundProduct = product;
                }
                else
                {
                    if(isProductInInventory == true)
                    {
                        break;
                    }
                    isProductInInventory = false;
                }
                
            }
            if(isProductInInventory == true)
            {
                Console.WriteLine($"Found product {foundProduct.name}");
                showProductInfo(foundProduct);
            }
            else
            {
                Console.WriteLine($"Product {productName} not found in inventory");
            }
            return foundProduct;
        }

        

        public void showProductInfo(Product foundProduct)
        {
            //print product name, price, and average rating
            Console.WriteLine($"Product name: {foundProduct.name}");
            Console.WriteLine($"Product price: {foundProduct.price}");
            Console.WriteLine($"Product avg rating: {foundProduct.averageRating}");
        }
        public void addProductToCart(Product currentProduct)
        {
            shoppingCart.addProduct(currentProduct);
        }

        public Review giveRatingAndReview(Product thisProduct)
        {
            Review thisProductReview = new Review();
            //give rating & review
            Console.WriteLine("Please enter a rating 1-5");
            thisProductReview.rating = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a text review for this product");
            thisProductReview.text = Console.ReadLine();
            return thisProductReview;
        }

    }
}
