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

        [SerializeField]
        Event onPlayerWin;

        [SerializeField]
        Event onPlayerLost;

        public void GenerateGame()
        {
            onGameStarted.Raise();
        }

        public void OnPlayerStand()
        {
            int playerHand = PlayerHand.Instance.HandValue;
            int dealerHand = DealerHand.Instance.HandValue;

            DetermineWinner(playerHand, dealerHand);
            onGameEnded.Raise();
        }

        public void OnPlayerBust()
        {
            Debug.Log("Player Loses.");
            onGameEnded.Raise();
        }

        private void DetermineWinner(int playerA, int plaverB)
        {
            if (playerA > plaverB)
            {
                onPlayerWin.Raise();
            }
            else
            {
                onPlayerLost.Raise();
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3.0f);
            onGameEnded.Raise();
        }
    } 
}
