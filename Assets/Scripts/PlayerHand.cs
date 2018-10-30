using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {

        int handValue;

        float padding = 0.2f;

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.A) && Deck.Instance.transform.childCount > 0)
            {
                AddCardToHand();
                SetOrderInLayer();
                Debug.Log(handValue);
            }

        }

        public int HandValue { get { return handValue; } }

        private void AddCardToHand()
        {
            Transform deckCard = Deck.Instance.transform.GetChild(0);
            deckCard.transform.position = transform.position;
            handValue += deckCard.GetComponent<Card>().cardData.Value;
            deckCard.transform.parent = transform;
        }

        private void AdjustCards()
        {
            foreach (Transform child in transform)
            {
                Vector2 childPos = child.position;
                Vector2 newPos = new Vector2(transform.position.x - padding, transform.position.y);
                child.position = newPos;
            }
        }

        private void SetOrderInLayer()
        {
            int order = 0;
            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = order;
                order++;
            }
        }
    } 
}
