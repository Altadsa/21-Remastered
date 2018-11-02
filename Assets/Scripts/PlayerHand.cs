using UnityEngine;

namespace TwentyOneRemastered
{

    public class PlayerHand : Hand
    {
        #region VALUES

        [SerializeField]
        Event onPlayerHit;

        #endregion

        #region Singleton

        private static PlayerHand playerHand;
        private static object padlock = new object();

        public static PlayerHand Instance
        {
            get
            {
                lock(padlock)
                {
                    if (!playerHand)
                    {
                        playerHand = FindObjectOfType<PlayerHand>();
                    }
                    return playerHand;
                }
            }
        }
        #endregion

        #region UNITY LIFECYCLE

        #endregion

        #region PUBLIC FUNCTIONS

        public void PlayerHit()
        {
            base.Hit();
            onPlayerHit.Raise();
        }

        #endregion

    } 
}
