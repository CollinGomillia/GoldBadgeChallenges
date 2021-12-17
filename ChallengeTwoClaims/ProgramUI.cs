using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChallengeTwoPoco;
using ChallengeTwoRepo;
using static ChallengeTwoPoco.ClaimItems;

namespace ChallengeTwoClaims
{
    public class ProgramUI
    {
        private TwoRepository _repoClaims = new TwoRepository();
        
        public void Run()
        {
            Seed();
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to Komodo Claims Department!\n" + 
                "Choose a menu item:\n" + 
                "1. See all claims\n" +
                "2. Take care of next claim\n" + 
                "3. Enter a new claim\n" +
                "4. Exit");
        }
        private void RunApplication()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        SeeClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thanks for coming!");
                        Thread.Sleep(5000);
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void SeeClaims()
        {
            Console.Clear();

            var listClaims = _repoClaims.ReadClaims();


            Console.Clear();
            
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID       |    Claimtype     |   Description      |   Amount      |   Date of accident      |   Date of claim        |     Is Valid |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            foreach(var claims in listClaims)
            {
                DisplayClaimInfo(claims);

            }
            Console.ReadLine();
        } //This will let us see our claims
        private void DisplayClaimInfo(ClaimItems claimItems) //Helper method for SeeClaims()
        {
            
            Console.WriteLine($"{claimItems.ClaimID, 1}        |{claimItems.TypeOfClaims, 11}       |{claimItems.Description, 10}          |{claimItems.ClaimAmount,5}          |{claimItems.DateOfIncident, 10}    |{claimItems.DateOfClaim, 10}  |{claimItems.IsValid, 10}");
            
        }
        private void GetNextClaim()
        {
            Console.Clear();
            var nextClaim = _repoClaims.NextClaim();
            DisplayClaimInfo(nextClaim);
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string claimUserIn = Console.ReadLine().ToUpper();
            if(claimUserIn == "Y")
            {
                var passed = _repoClaims.DeleteClaims();
                if(passed)
                {
                    Console.WriteLine("Good job! Your claim is finished!");
                }
                else if(!passed)
                {
                    Console.WriteLine("Oops!! ,something went wrong with your claim...");
                    RunApplication();
                }
            }
            else
            {
                RunApplication();
            }
            Console.ReadKey();

        } //This will move us to the next claim
        private void NewClaim()
        {
            Console.Clear();
            ClaimItems newClaim = new ClaimItems();

            Console.WriteLine("Enter the claim id: ");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choose from 1.Car \n" +
                "2.Home\n" +
                "3.Theft\n ");
            int numberClaim = int.Parse(Console.ReadLine());
            //Changes int to type
            ClaimType claimType = (ClaimType)numberClaim;
            newClaim.TypeOfClaims = claimType;

            Console.WriteLine("Enter a claim description: ");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            //Can't figure out how to fix date times or can have help entering date as user input
            Console.WriteLine("Enter the date of incident(YYYY,MM,DD): ");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfIncident = incidentDate;
            Console.WriteLine("Enter the date of claim(YYYY,MM,DD): ");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = claimDate;

            newClaim.IsValid = IsClaimValid(claimDate, incidentDate);

            _repoClaims.CreateClaim(newClaim);
            
        }
        


        public bool IsClaimValid(DateTime claimDate, DateTime incidentDate)
        {
            //calculate date times
            var validDates = claimDate - incidentDate;
            //timespan to calculate days
            double days = validDates.Days;
            //if days < 30 -do something
            if(days < 30)
            {
                Console.WriteLine("Valid");
                return true;
            }
            else
            {
                Console.WriteLine("InValid");
                return false;
            }
            

        }

        private void Seed()
        {
            ClaimItems itemOne = new ClaimItems(1,"Car crash",2200.00,new DateTime(2020, 12, 12),new DateTime(2020, 12, 13),true, ClaimItems.ClaimType.Car);
            ClaimItems itemTwo = new ClaimItems(2,"House Fire",2200.00,new DateTime(2010, 12, 12),new DateTime(2010, 12, 13),true, ClaimItems.ClaimType.Home);
            ClaimItems itemThree = new ClaimItems(3,"Burglary",2200.00,new DateTime(2020, 9, 12),new DateTime(2020, 10, 13),true, ClaimItems.ClaimType.Theft);
           

            _repoClaims.CreateClaim(itemOne);
            _repoClaims.CreateClaim(itemThree);
            _repoClaims.CreateClaim(itemTwo);
          

        }//Seed to test the project
    }
}
