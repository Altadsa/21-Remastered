using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(PlayerHand))]
    public class Player : CardHandler
    {

        [SerializeField]
        Event onPlayerBust;

        [SerializeField]
        Event onPlayerStand;

        [SerializeField]
        Event onGameReady;

        #region PUBLIC FUNCTIONS

        public override void OnGameGenerated()
        {
            base.OnGameGenerated();
            onGameReady.Raise();
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
            handInstance.Hit();
        }

        public void PlayerStand()
        {
            onPlayerStand.Raise();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        #endregion
    } 
}
