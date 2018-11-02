using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(DealerHand))]
    public class Dealer : MonoBehaviour
    {

        private int handValue;

        public void OnGameGenerated()
        {
            StartCoroutine(DrawStartingCards());
        }

        IEnumerator DrawStartingCards()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(1.0f);
                DealerHand.Instance.DealerHit();
            }
        }

    } 
}
