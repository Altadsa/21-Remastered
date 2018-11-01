using UnityEngine;

namespace TwentyOneRemastered
{
    public class DealerHand : MonoBehaviour
    {
        [SerializeField]
        Sprite faceDownCardSprite;

        int handValue;

        float padding = 0.5f;

        #region Singleton

        private static DealerHand playerHand;
        private static object padlock = new object();

        public static DealerHand Instance
        {
            get
            {
                lock (padlock)
                {
                    if (!playerHand)
                    {
                        playerHand = FindObjectOfType<DealerHand>();
                    }
                    return playerHand;
                }
            }
        }
        #endregion

        public int HandValue {  get { return handValue; } }

        public void DealerHit()
        {
            AddCardAndAdjustHand();
        }

        public void OnPlayerStand()
        {
            foreach (Transform child in transform)
            {
                Card childCard = child.GetComponent<Card>();
                SpriteRenderer childSR = child.GetComponent<SpriteRenderer>();
                if (childCard && childSR)
                {
                    childSR.sprite = childCard.cardData.CardSprite;
                }
            }
        }

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
            SetFaceDownIfFirstCard(deckCard);
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
        
        private void SetFaceDownIfFirstCard(Transform cardToCheck)
        {
            if (transform.childCount == 2)
            {
                SpriteRenderer cardSR = cardToCheck.GetComponent<SpriteRenderer>();
                if (cardSR)
                {
                    cardSR.sprite = faceDownCardSprite;
                } 
            }
        }
    } 
}
