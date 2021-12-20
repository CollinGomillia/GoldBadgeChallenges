using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThreePoco;

namespace ChallengeThreeRepo
{
    public class ThreeRepo
    {
        private Dictionary<int, BadgeItems> _badgeItem = new Dictionary<int, BadgeItems>();
        private int _count = 0;

        //Create
        public bool CreateBadge(BadgeItems badgeItems)
        {
            if (badgeItems == null)
            {
                return false;
            }
            _count++;
            badgeItems.BadgeID = _count;
            _badgeItem.Add(badgeItems.BadgeID,badgeItems); 
            return true;
        }
        //Read
        public Dictionary<int, BadgeItems> ReadBadges()
        {
            return _badgeItem;
        }
        //Get badge by Id
        public BadgeItems GetBadgeByID(int BadgeID)
        {
            foreach(KeyValuePair<int,BadgeItems> badgeItems in _badgeItem)
            {
                if(BadgeID == badgeItems.Key)
                {
                    return badgeItems.Value;
                }
            }
            return null;
        }
        //Update
        public bool UpdateBadge(int BadgeID, BadgeItems newBadgeData)
        {
            BadgeItems oldBadgeData = GetBadgeByID(BadgeID);
            if(oldBadgeData != null)
            {
                oldBadgeData.BadgeID = newBadgeData.BadgeID;
                oldBadgeData.DoorNames = oldBadgeData.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteDoor(int badgeId)
        {
            var badge = GetBadgeByID(badgeId);
           
            if(badge == null)
            {
                return false;
            }
            foreach(var door in badge.DoorNames)
            {
               
                    badge.DoorNames.Remove(door);
                    return true;
                
            }
            return false;
        }
       

    }
}
