using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(PlayerHand))]
    public class Player : CardHandler
    {

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
