using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {
        #region VALUES

        int handValue;

        float padding = 0.2f; 

        #endregion

        #region UNITY LIFECYCLE

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && Deck.Instance.transform.childCount > 0)
            {
                AddCardToHand();
                SetOrderInLayer();
                AdjustCardPositions();
            }

        } 

        #endregion


        #region PRIVATE FUNCTIONS

        private void AddCardToHand()
        {
            Transform deckCard = Deck.Instance.transform.GetChild(0);
            deckCard.transform.position = transform.position;
            handValue += deckCard.GetComponent<Card>().cardData.Value;
            deckCard.transform.parent = transform;
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

        private void AdjustCardPositions()
        {
            if (transform.childCount < 1) { return; }
            foreach (Transform child in transform)
            {
                AdjustCard(child);
            }
        }

        private void AdjustCard(Transform cardToAdjust)
        {
            Vector2 cardPosition = cardToAdjust.transform.position;
            Vector2 newPos = new Vector2(cardPosition.x - padding, cardPosition.y);
            cardToAdjust.transform.position = newPos;
        }

        #endregion
    } 
}
