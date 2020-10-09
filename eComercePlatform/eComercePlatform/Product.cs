using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComercePlatform
{
    class Product
    {
        //member variables (HAS)
        public int uniqueIdentifier;
        public string name;
        public string category;
        public double price;
        public double averageRating;
        public List<Review> reviews;
        //constructor (SPAWNER/CREATOR)

        public Product(int uniqueIdentifier, string name, string category, double price)
        {
            this.uniqueIdentifier = uniqueIdentifier;
            this.name = name;
            this.category = category;
            this.price = price;
            averageRating = 0;
            reviews = new List<Review>();
        }

        //member methods (CAN DO)
        public void addReview(Review newReview)
        {
            reviews.Add(newReview);
            double sum = 0;
            for (int i = 0; i < reviews.Count; i++)
            {
                sum += reviews[i].rating;
                if(i == (reviews.Count - 1)){
                    averageRating = sum / reviews.Count;
                }
            }
        }

    }
}
