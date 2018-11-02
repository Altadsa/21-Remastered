using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        Event onGameEnded;

        [SerializeField]
        Event onGameStarted;

        public void GenerateGame()
        {
            onGameStarted.Raise();
        }

        public void OnPlayerStand()
        {
            int playerHand = PlayerHand.Instance.HandValue;
            int dealerHand = DealerHand.Instance.HandValue;

            DetermineWinner(playerHand, dealerHand);
            StartCoroutine(EndGame());
        }

        public void OnPlayerBust()
        {
            Debug.Log("Player Loses.");
            StartCoroutine(EndGame());
        }

        private void DetermineWinner(int playerA, int plaverB)
        {
            if (playerA > plaverB) { Debug.Log("Player Wins"); }
            else { Debug.Log("Player Loses"); }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3.0f);
            onGameEnded.Raise();
        }
    } 
}
