using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeOnePoco;
using ChallengeOneRepo;

namespace ChallengeOneCafe
{
    public class ProgramUI
    {
        private readonly Repository _cafeRepo = new Repository();
        public void Run()
        {
            Seed();
            RunApplication();
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to Komodo Cafe!\n" +
                "1. Create Menu Items\n" +
                "2. View Menu\n" +
                "3. Delete Menu Items\n" +
                "4. Exit");
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thanks for using the Komodo Cafe App!!!");
                        break;
                    default:
                        break;
                }
            }
        }
        private void CreateMenuItem()
        {
            Console.Clear();
            //Get name of meal
            Console.WriteLine("What's the name of your meal?");
            string userInputMealName = Console.ReadLine();
            Console.WriteLine();
            //Get number of number
            Console.WriteLine("Pick a number for your meal!");
            int userInputMealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            //Give description of meal
            Console.WriteLine("Describe this meal!");
            string userInputDescription = Console.ReadLine();
            Console.WriteLine();
            //Give Ingredients to meal
            Console.WriteLine("Enter ingredients, and seperate by commas");
            string userInputIngredients = Console.ReadLine();
            Console.WriteLine();
            //Give price of meal
            Console.WriteLine("How much does this cost?");
            double userInputPrice = double.Parse(Console.ReadLine());
            Console.WriteLine();
            //Add Ingredients
            MenuItems itemsToBeAdded = new MenuItems(userInputMealName, userInputMealNumber, userInputDescription, userInputIngredients, userInputPrice);

            bool isAdded = _cafeRepo.AddItemToList(itemsToBeAdded);
            if (isAdded)
            {
                Console.WriteLine($"{userInputMealName} was successfully added!!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{userInputMealName} was not successfully added...");
                Console.ReadLine();
            }
        }
        private void ViewMenu()
        {
            Console.Clear();

            List<MenuItems> listOfAllItems = _cafeRepo.ReadItemList();

            foreach (var menuItems in listOfAllItems)
            {
                DisplayItemInfo(menuItems);
            }
            Console.WriteLine("Press enter...");
            Console.ReadKey();
        }
        private void DisplayItemInfo(MenuItems menuItems) //Helper Method
        {
            Console.WriteLine($"Meal name: {menuItems.MealName}\n" +
                $"Meal number: {menuItems.MealNumber}\n" +
                $"Meal description: {menuItems.Description}\n" +
                $"Meal ingredients: {menuItems.Ingredients}\n" +
                $"Meal price: {menuItems.Price}\n");
            Console.WriteLine("******************************");
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private void DeleteItem()
        {
            Console.Clear();

            ViewMenu();

            Console.WriteLine("Enter the menu item number you would like to delete...");
            int mealNumber = int.Parse(Console.ReadLine());
            bool deleted = _cafeRepo.DeleteItem(mealNumber);
            if (deleted)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Your item was successfully deleted!");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.WriteLine("Error: was not deleted...");
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        private void Seed()
        {
            MenuItems LobsterTail = new MenuItems("Lobster Tail", 3, "Flavorful lobster straight from Maine.", "", 20.00);
            MenuItems PhillySteak = new MenuItems("Philly", 2, "Onions,steak,cheese and the works on a bun", "", 10.00);

            _cafeRepo.AddItemToList(LobsterTail);
            _cafeRepo.AddItemToList(PhillySteak);
        }
    }
}