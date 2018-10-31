using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {
        #region VALUES

        [SerializeField]
        Event onPlayerHit;

        int handValue;

        float padding = 0.5f;

        #endregion

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

        #region UNITY LIFECYCLE

        #endregion

        #region PUBLIC FUNCTIONS

        public int HandValue {  get { return handValue; } }

        public void PlayerHit()
        {
            AddCardToHand();
            SetOrderInLayer();
            AdjustCardPositions();
            onPlayerHit.Raise();
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
