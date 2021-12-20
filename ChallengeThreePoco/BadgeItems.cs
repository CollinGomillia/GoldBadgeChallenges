using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreePoco
{
    public class BadgeItems
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }

        public BadgeItems()
        {

        }

        public BadgeItems(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
