using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class GameManager : MonoBehaviour
    {

        public void OnPlayerStand()
        {
            int playerHand = PlayerHand.Instance.HandValue;
            int dealerHand = DealerHand.Instance.HandValue;

            DetermineWinner(playerHand, dealerHand);
        }

        private void DetermineWinner(int playerA, int plaverB)
        {
            if (playerA > plaverB) { Debug.Log("Player Wins"); }
            else { Debug.Log("Player Loses"); }
        }
    } 
}
