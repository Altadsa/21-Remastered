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

        public void StartGame()
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
            onPlayerLost.Raise();
            onGameEnded.Raise();
        }

        private void DetermineWinner(int playerA, int plaverB)
        {
            if (playerA > plaverB)
            {
                Debug.Log("Player Wins");
                onPlayerWin.Raise();
            }
            else
            {
                Debug.Log("Player Loses");
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
