using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        Sprite defaultSprite;

        public CardData cardData;

        string cardName;
        int cardValue;
        CardSuit suit;

        // Use this for initialization
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #region PRIVATE FUNCTIONS

        void Initialize()
        {
            cardName = cardData.CardName;
            cardValue = cardData.Value;
            suit = cardData.CardSuit;
            if (cardData.CardSprite)
            {
                GetComponent<SpriteRenderer>().sprite = cardData.CardSprite;
                return;
            }
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }

        #endregion
    } 
}
