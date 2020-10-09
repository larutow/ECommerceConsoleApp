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
            inventory.Add(CreateProduct(1, "Blue Shoes", "Clothing", 49.99));
            inventory.Add(CreateProduct(2, "PS5", "Videogames", 499.99));
            inventory.Add(CreateProduct(3, "Pixel 4a", "Cellphones", 350.00));
            inventory.Add(CreateProduct(4, "Infinite Jest", "Books", 14.99));
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
            Console.WriteLine("2. Account Information");
            Console.WriteLine("3. Exit Application");
            
        }

        public void DisplaySearchMenu(Product foundProduct)
        {
            Console.WriteLine("Found Product Options:");
            Console.WriteLine($"1. Add {foundProduct.name} To Cart");
            Console.WriteLine($"2. Leave a rating & review for {foundProduct.name}");
            Console.WriteLine($"3. Return to main menu");
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

        public void AccountMenu()
        {


        }

        public void UsePlatform(Consumer consumer)
        {
            /* From docs:
             * The workflow consists of the following:
                a. Search for product
                b. See information about product
                c. Add product to shopping cart
                d. Give product a rating
                e. Give product a review

              I think the below is a good way to structure menu navigation
            * Home Menu
            * 1. Search
            *   a. Find product
            *       i.   see information
            *       ii.  add to cart
            *       iii. leave a rating
            *       iv.  leave a review
            *       v.   return to home
            *   b. Not find product
            *       i.   Search again?
            *       ii.  Exit
            * 2. Account Info
            *   a. Update First Name
            *   b. Update Last Name
            *   c. Return to home
            * 3. Exit
            * 
            * 
            * I literally hate the below code but it works and I need to refactor it into clean submenus
             */
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
                        //do account things here
                        break;
                    case 3:
                        exit = true;
                        break;

                    default:
                        exit = true;
                        break;
                }    
            } while (exit == false);
            //show menu
            //control

        }




    }
}
