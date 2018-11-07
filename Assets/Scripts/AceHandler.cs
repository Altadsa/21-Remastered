using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class AceHandler : MonoBehaviour
    {
        [SerializeField]
        Event onPlayerStand;

        [SerializeField]
        Event onPlayerBust;

        int firstHandValue, secondHandValue;

        Hand hand;

        bool doesAceExist = false;



        public void OnGameStarted()
        {
            firstHandValue = 0;
            secondHandValue = 0;
            hand = GetComponent<Hand>();
            doesAceExist = false;
        }

        public void OnPlayerHit()
        {
            Initialize();
            if (hand.HandValue > 21)
            {
                onPlayerBust.Raise();
            }
        }

        public void OnPlayerStand()
        {
            if (secondHandValue == 0) { return; }
            if (secondHandValue < 22)
            {
                hand.HandValue = secondHandValue;
                Debug.Log("New hand value: " + hand.HandValue);
            }
        }

        private void Initialize()
        {
            CheckIfAceExists();

            if (doesAceExist)
            {
                firstHandValue = hand.HandValue;
                secondHandValue = firstHandValue + 10;
                CheckForBlackjack();
                Debug.Log(string.Format("First Hand: {0}, Second Hand: {1}", firstHandValue, secondHandValue)); 
            }
        }

        private void CheckIfAceExists()
        {
            foreach (Transform card in hand.gameObject.transform)
            {
                Card childCard = card.GetComponent<Card>();
                if (childCard.cardData.Value == 1)
                {
                    doesAceExist = true;
                }
            }
        }

        private void CheckForBlackjack()
        {
            if (!hand) { return; }
            if (hand.transform.childCount == 2 && secondHandValue == 21)
            {
                Debug.Log("Blackjack for " + hand.name);
                onPlayerStand.Raise();
            }
        }
    } 
}
