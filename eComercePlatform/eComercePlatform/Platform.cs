using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eComercePlatform
{
    class Platform
    {
        //member variables (HAS)
        public List<Product> inventory;
        public bool exit = false;

        //constructor (SPAWNER/CREATOR)
        public Platform()
        {
            inventory = new List<Product>();
            PopulateInventory(CreateProduct(1, "Blue Shoes", "Clothing", 49.99));
            PopulateInventory(CreateProduct(2, "PS5", "Videogames", 499.99));
            PopulateInventory(CreateProduct(3, "Pixel 4a", "Cellphones", 350.00));
            PopulateInventory(CreateProduct(4, "Infinite Jest", "Books", 14.99));
        }
        //member methods (CAN DO)

        public Product CreateProduct(int uniqueIdentifier, string name, string category, double price)
        {
            Product product = new Product(uniqueIdentifier, name, category, price);
            
            return product;
        }

        private void PopulateInventory(Product product)
        {
            //Below isn't needed since we're manipulating the object directly (for reviews for example)
            //bool isProductUnique = false;
            //foreach(Product item in inventory)
            //{
                
            //    if(product.uniqueIdentifier == 0)
            //    {
            //        Console.WriteLine("Protected Item (Item Not Found) - no operation performed - this is a shitty error / catch code");
            //    }
            //    else if(product.uniqueIdentifier == item.uniqueIdentifier)
            //    {
            //        item.name = product.name;
            //        item.category = product.category;
            //        item.price = product.price;
            //        item.averageRating = product.averageRating;
            //        item.reviews = product.reviews;
            //    } else if(isProductUnique == false)
            //    {
            //        inventory.Add(product);
            //    }
            //}
            
            inventory.Add(product);
            // use a doc to build product inventory??
        }

        public void DisplayHomeMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Search for product");
            Console.WriteLine("2. Show Cart");
            Console.WriteLine("3. Account Information");
            Console.WriteLine("4. Exit Application");
            
        }

        public void DisplaySearchMenu(Product foundProduct)
        {
            Console.WriteLine("Found Product Options:");
            Console.WriteLine($"1. Add {foundProduct.name} To Cart");
            Console.WriteLine($"2. Leave a rating & review for {foundProduct.name}");
            Console.WriteLine($"3. Return to main menu");
        }

        public void DisplayCartMenu(Consumer consumer)
        {
            Console.WriteLine("Cart Menu:");
            Console.WriteLine(/*consumer cart*/"Cart Contains:");
            //show cart contents method?
            Console.WriteLine("1. Delete Items In Cart");
            Console.WriteLine("2. Check Out Items In Cart");
            Console.WriteLine("3. Return to Main Menu");

        }

        public void DisplayAccountMenu(Consumer consumer)
        {
            Console.WriteLine("Account Menu:");
            //State/context dependent menu:
            //if new/not signed in user: create account
            //if new/not signed in user: sign into an existing account
            //if signed in user: sign out
            //if signed in user: update account information
            //if signed in user: delete account
            //Console.WriteLine("1. Create an account");
            //Console.WriteLine("2. Enter Email");
            //Console.WriteLine("3. Account Information");
            //Console.WriteLine("4. Exit Application");

        }

        public void SearchMenu(Consumer consumer)
        {
            Console.WriteLine("Enter product name you'd like to search");
            Product foundProduct = consumer.searchProduct(Console.ReadLine(), inventory);
            if (foundProduct.uniqueIdentifier != 0)
            {
                DisplaySearchMenu(foundProduct);
                int searchOption = int.Parse(Console.ReadLine());
                switch (searchOption)
                {
                    case 1:
                        consumer.addProductToCart(foundProduct);
                        Console.WriteLine("Product successfully added to cart - Press any key to return to the main menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        foundProduct.addReview(consumer.giveRatingAndReview(foundProduct));
                        //PopulateInventory(foundProduct);
                        Console.WriteLine("Thanks for your feedback - your feedback has been documented - Press any key to continue to the main menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid entry - Press any key to continue to the main menu");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadLine();
                Console.Clear();
            }
        }


        public void CartMenu(Consumer consumer)
        {
            //operations for consumer's cart

        }
        public void AccountMenu(Consumer consumer)
        {
            //operations consumer's account information

        }

        public void UsePlatform(Consumer consumer)
        {
            
            Console.WriteLine("Welcome to C#azon");
            bool exit = false;
            do
            {
                DisplayHomeMenu();
                int userEntry = int.Parse(Console.ReadLine());
                switch (userEntry)
                {
                    case 1:
                        SearchMenu(consumer);
                        break;
                    case 2:
                        //cart menu
                        CartMenu(consumer);
                        break;
                    case 3:
                        AccountMenu(consumer);
                        break;
                    case 4:
                        exit = true;
                        break;

                    default:
                        exit = true;
                        break;
                }
            } while (exit == false);
        }
    }
}
