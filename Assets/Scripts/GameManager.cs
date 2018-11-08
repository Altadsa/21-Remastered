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
        Event onReturnToMenu;

        [SerializeField]
        Event onPlayerWin;

        [SerializeField]
        Event onPlayerLost;

        public void StartGame()
        {
            onGameStarted.Raise();
        }

        public void ReturnToMenu()
        {
            onReturnToMenu.Raise();
        }

        public void OnPlayerStand()
        {
            onGameEnded.Raise();
        }

        public void OnPlayerBust()
        {
            Debug.Log("Player Loses.");
            onGameEnded.Raise();
        }

        public void OnGameEnded()
        {
            StartCoroutine(CompareScoresAndDetermineWinner());
        }

        private void DetermineWinner(int playerA, int playerB)
        {
            Debug.Log(string.Format("Player: {0} | Dealer: {1}", playerA, playerB));
            if (playerA > playerB && playerA <= 21)
            {
                Debug.Log("Player Wins");
                onPlayerWin.Raise();
            }
            else if (playerA < playerB && playerB > 21)
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

        IEnumerator CompareScoresAndDetermineWinner()
        {
            yield return new WaitForSeconds(2.0f);
            int playerHand = PlayerHand.Instance.HandValue;
            int dealerHand = DealerHand.Instance.HandValue;
            DetermineWinner(playerHand, dealerHand);
        }
    } 
}
