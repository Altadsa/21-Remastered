using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(PlayerHand))]
    public class Player : MonoBehaviour
    {

        [SerializeField]
        Event onPlayerBust;

        [SerializeField]
        Event onPlayerStand;

        private bool isPlayersTurn = false;

        private int handValue;

        #region Singleton

        private static Player player;
        private static object padlock = new object();
        public static Player Instance
        {
            get
            {
                lock(padlock)
                {
                    if (!player)
                    {
                        player = FindObjectOfType<Player>();
                    }
                    return player;
                }
            }
        }

        #endregion

        #region UNITY LIFECYCLE

        #endregion

        #region PUBLIC FUNCTIONS

        public void OnGameGenerated()
        {
            DrawStartingCards();
        }

        public void OnGameStarted()
        {
            isPlayersTurn = true;
        }

        public void OnPlayerHit()
        {
            handValue = PlayerHand.Instance.HandValue;
            if (handValue > 21)
            {
                isPlayersTurn = false;
                onPlayerBust.Raise();
            }
        }

        public void PlayerHit()
        {
            if (!isPlayersTurn) { return; }
            PlayerHand.Instance.PlayerHit();
        }

        public void PlayerStand()
        {
            if (!isPlayersTurn || handValue < 1) { return; }
            isPlayersTurn = false;
            onPlayerStand.Raise();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void DrawStartingCards()
        {
            for (int i = 0; i < 2; i++)
            {
                PlayerHand.Instance.PlayerHit();
            }
        }

        #endregion
    } 
}
