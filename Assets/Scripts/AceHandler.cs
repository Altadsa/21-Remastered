using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class AceHandler : MonoBehaviour
    {
        [SerializeField]
        Event onPlayerStand;

        int firstHandValue = 0;

        int secondHandValue = 0;

        Hand hand;

        private void OnEnable()
        {
            hand = GetComponent<Hand>();
        }

        public void Initialize()
        {
            firstHandValue = hand.HandValue;
            secondHandValue = firstHandValue + 10;
            CheckForBlackjack();
            Debug.Log(string.Format("First Hand: {0}, Second Hand: {1}", firstHandValue, secondHandValue));
        }

        private void CheckForBlackjack()
        {
            if (hand.transform.childCount == 2 && secondHandValue == 21)
            {
                Debug.Log("Blackjack for " + hand.name);
                onPlayerStand.Raise();
            }
        }
    } 
}
