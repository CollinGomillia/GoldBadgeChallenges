using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChallengeThreePoco;
using ChallengeThreeRepo;

namespace ChallengeThreeBadges
{
    public class ProgramUI
    {
        private ThreeRepo _repoBadges = new ThreeRepo();

        public void Run()
        {
            //Seed();
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Hello Security Admin,What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges\n" +
                "4. Exit\n");
        }

        private void RunApplication()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                Menu();
                string userIN = Console.ReadLine();

                switch(userIN)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for coming!");
                        Thread.Sleep(5000);
                        isRunning = false;
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }

        private void AddBadge()
        {
            Console.Clear();
            BadgeItems addBadge = new BadgeItems();
            List<string> DoorNames = new List<string>();

            Console.WriteLine("What is the number on the badge: ");
            int number = Convert.ToInt32(Console.ReadLine());
            addBadge.BadgeID = number;
            

            Console.WriteLine("List a door that it needs access to: ");
            string input = Console.ReadLine();
            DoorNames.Add(input);

            bool addingDoors = true;
            while(addingDoors)
            {
                Console.WriteLine("Any other door(y/n)? ");
                string userInput = Console.ReadLine().ToUpper();

                if(userInput == "Y")
                {
                    Console.WriteLine("List a door it needs access to: ");
                    string access = Console.ReadLine();
                    DoorNames.Add(access);

                }
                else
                {
                    addingDoors = false;

                }

            }
            addBadge.DoorNames = DoorNames;
            _repoBadges.CreateBadge(addBadge);
        }

        private void HelperBadges(BadgeItems badgeItems)
        {
            Console.WriteLine("Badge#   |    Door Access");
            Console.WriteLine();

            foreach(var doors in badgeItems.DoorNames)
            {
                Console.Write(doors);
            }
        }
        private void ListBadges()
        {
            Console.Clear();

            var listAllBadges = _repoBadges.ReadBadges();

            foreach(var badgeItems in listAllBadges)
            {
                HelperBadges(badgeItems.Value);
            }
        }

        private void EditBadge()
        {
            Console.Clear();

            Console.WriteLine("What is the badge number to update? ");
            int userIN = Convert.ToInt32(Console.ReadLine());

            BadgeItems getID = _repoBadges.GetBadgeByID(userIN);
            List<string> doors = getID.DoorNames;

            Console.WriteLine($"{userIN} has access to doors {getID.DoorNames}");
            Console.WriteLine();

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Which door would you like to remove? ");
                string doorChoice = Console.ReadLine();
                doors.Remove(doorChoice);

            }
            else if (choice == 2)
            {
                Console.WriteLine("What door will we be adding? ");
                string added = Console.ReadLine();
                doors.Add(added);
            }
            getID.DoorNames = doors;
            _repoBadges.UpdateBadge(userIN, getID);



        }
    }
}
