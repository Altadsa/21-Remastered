using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(DealerHand))]
    public class Dealer : CardHandler
    {
        [SerializeField]
        Event onDealerStand;

        [SerializeField]
        Event onDealerHit;

        Hand dealerHand;

        int handValue;

        bool drawAnotherCard;

        public void OnPlayerStand()
        {
            dealerHand = GetComponent<Hand>();
            handValue = dealerHand.HandValue;
            HitIfPossible();
        }

        private void HitIfPossible()
        {
            if (handValue < 15)
            {
                onDealerHit.Raise();
            }
            onDealerStand.Raise();
        }
    } 
}
