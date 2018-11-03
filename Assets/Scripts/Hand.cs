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

        #region PUBLIC FUNCTIONS

        public int HandValue { get { return handValue; } }

        public void Hit()
        {
            AddCardAndAdjustHand();
            HandleAceIfExists();
        }

        public void ReturnCardsToDeck()
        {
            Transform card;
            while (transform.childCount > 0)
            {
                card = transform.GetChild(0);
                card.transform.parent = Deck.Instance.transform;
                card.GetComponent<Card>().MoveCard();
                card.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }

        public void OnGameStarted()
        {
            handValue = 0;
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void AddCardAndAdjustHand()
        {
            AddCardToHand();
            SetOrderInLayer();
            AdjustCardPositions();
        }

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
