using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoPoco
{
    public class ClaimItems
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft
        }

        public int ClaimID { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimType TypeOfClaims { get; set; }

        public ClaimItems()
        {

        }

        public ClaimItems(int claimID, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid, ClaimType typeOfClaims)
        {
            ClaimID = claimID;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            TypeOfClaims = typeOfClaims;
        }
        public ClaimItems(string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
