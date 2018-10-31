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

        public void OnPlayerHit()
        {
            int handValue = PlayerHand.Instance.HandValue;
            if (handValue > 21)
            {
                Debug.Log("Bust!");
            }
        }

    } 
}
