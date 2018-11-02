using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(AceHandler))]
    public abstract class Hand : MonoBehaviour
    {
        #region VALUES

        protected int handValue;

        protected float padding = 0.5f;

        #endregion

        #region UNITY LIFECYCLE

        private void OnDisable()
        {
            handValue = 0;
        }

        #endregion

        #region PUBLIC FUNCTIONS

        public int HandValue { get { return handValue; } }

        public void Hit()
        {
            AddCardAndAdjustHand();
            HandleAceIfExists();
        }

        private void AddCardAndAdjustHand()
        {
            AddCardToHand();
            SetOrderInLayer();
            AdjustCardPositions();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void HandleAceIfExists()
        {
            Card[] cardsInHand = GetComponentsInChildren<Card>();
            foreach (Card card in cardsInHand)
            {
                if (card.cardData.Value == 1)
                {
                    GetComponent<AceHandler>().Initialize();
                }
            }
        }

        private void AddCardToHand()
        {
            Transform deckCard = Deck.Instance.transform.GetChild(0);
            deckCard.transform.parent = transform;
            deckCard.GetComponent<Card>().MoveCard();
            handValue += deckCard.GetComponent<Card>().cardData.Value;
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
