﻿using System.Collections;
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

        public void OnGameStarted()
        {
            StartCoroutine(DrawStartingCards());
        }

        public void OnPlayerHit()
        {
            handValue = PlayerHand.Instance.HandValue;
            if (handValue > 21)
            {
                onPlayerBust.Raise();
            }
        }

        public void PlayerHit()
        {
            PlayerHand.Instance.PlayerHit();
        }

        public void PlayerStand()
        {
            onPlayerStand.Raise();
        }

        #endregion

        #region PRIVATE FUNCTIONS

       IEnumerator DrawStartingCards()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(1.0f);
                PlayerHand.Instance.PlayerHit();
            }
        }

        #endregion
    } 
}
