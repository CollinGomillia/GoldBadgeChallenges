using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOnePoco
{
    public class MenuItems
    {
        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItems()
        {

        }

        public MenuItems(string mealName, int mealNumber, string description, string ingredients, double price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;



        }



    }
}
