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

        private bool isPlayersTurn = true;

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

        public bool IsPlayerTurn { get { return isPlayersTurn; } }

        public void OnPlayerHit()
        {
            int handValue = PlayerHand.Instance.HandValue;
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
            if (!isPlayersTurn) { return; }
            isPlayersTurn = false;
        }

    } 
}
