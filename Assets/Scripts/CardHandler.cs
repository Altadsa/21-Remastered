using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    public abstract class CardHandler : MonoBehaviour
    {
        protected int handValue;

        protected Hand handInstance;

        private void Start()
        {
            handInstance = GetComponent<Hand>();
        }

        public virtual void OnGameGenerated()
        {
            StartCoroutine(DrawStartingCards());
        }

        IEnumerator DrawStartingCards()
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(1.0f);
                handInstance.Hit();
            }
        }

    } 
}
