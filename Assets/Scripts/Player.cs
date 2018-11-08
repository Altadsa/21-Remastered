using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(PlayerHand))]
    public class Player : CardHandler
    {

        [SerializeField]
        Event onPlayerStand;

        #region PUBLIC FUNCTIONS

        public void PlayerHit()
        {
            onHit.Raise();
        }

        public void PlayerStand()
        {
            onPlayerStand.Raise();
        }

        #endregion

    } 
}
