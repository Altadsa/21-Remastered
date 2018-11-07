using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : Hand
    {

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

        #region PUBLIC FUNCTIONS

        public override void OnHit()
        {
            base.OnHit();
        }

        #endregion
    } 
}
