using UnityEngine;

namespace TwentyOneRemastered
{
    public class DealerHand : Hand
    {
        [SerializeField]
        Sprite faceDownCardSprite;

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

        public void DealerHit()
        {
            base.Hit();
            SetFaceDownIfFirstCard();
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
        
        private void SetFaceDownIfFirstCard()
        {
            Transform firstCard = transform.GetChild(0);
            if (firstCard)
            {
                SpriteRenderer cardSR = firstCard.GetComponent<SpriteRenderer>();
                if (cardSR)
                {
                    cardSR.sprite = faceDownCardSprite;
                } 
            }
        }
    } 
}
