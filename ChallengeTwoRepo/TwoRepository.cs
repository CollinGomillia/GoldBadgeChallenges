using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoPoco;

namespace ChallengeTwoRepo
{
    public class TwoRepository
    {
       private readonly Queue<ClaimItems> _claimItems = new Queue<ClaimItems>();
       private int _count = 0;
       //Create
       public bool CreateClaim(ClaimItems claimItems)
       {
            if(claimItems == null)
            {
                return false;
            }
            _count++;
            claimItems.ClaimID = _count;
            _claimItems.Enqueue(claimItems);
            return true;
       }
       //Read
       public Queue<ClaimItems> ReadClaims()
       {
            return _claimItems;
       }
       //Get next claim
       public ClaimItems NextClaim()
       {
            var claim = _claimItems.Peek();
            if(claim != null)
            {
                return claim;
            }
            return null;
       }
       //Delete Claim
       public bool DeleteClaims()
       {
            if(_claimItems.Count > 0)
            {
                _claimItems.Dequeue();
                return true;
            }
            return false;





       }
       

    }
}
