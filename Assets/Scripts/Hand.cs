using UnityEngine;

namespace TwentyOneRemastered
{
    [RequireComponent(typeof(CardHandler))]
    [RequireComponent(typeof(AceHandler))]
    public abstract class Hand : MonoBehaviour
    {
        #region VALUES

        protected int handValue;

        protected float padding = 0.5f;

        #endregion

        #region PUBLIC FUNCTIONS

        public int HandValue { get { return handValue; } set { handValue = value; } }

        public virtual void OnHit()
        {
            AddCardAndAdjustHand();
        }

        public void ReturnCardsToDeck()
        {
            while (transform.childCount > 0)
            {
                ReturnCardToDeck();
            }
        }

        private void ReturnCardToDeck()
        {
            Transform card = transform.GetChild(0);
            SpriteRenderer cardSR = card.GetComponent<SpriteRenderer>();
            Card cardC = card.GetComponent<Card>();

            card.transform.parent = Deck.Instance.transform;
            cardC.MoveCard();
            cardSR.sortingOrder = 0;
            cardSR.sprite = cardC.cardData.CardSprite;
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
