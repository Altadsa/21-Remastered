using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    public sealed class Deck : MonoBehaviour
    {
        [SerializeField]
        Event onGameGenerated;

        [SerializeField]
        GameObject cardPrefab;

        [SerializeField]
        CardData[] cardDataArray;

        int childCount;

        #region SINGLETON

        private static Deck deck;
        private static object padlock = new object();

        public static Deck Instance
        {
            get
            {
                lock(padlock)
                {
                    if (!deck)
                    {
                        deck = FindObjectOfType<Deck>();
                    }
                    return deck;
                }
            }
        }

        #endregion

        #region PUBLIC FUNCTIONS

        public void Initialize()
        {
            childCount = transform.childCount;
            GenerateDeck();
            ReturnCards();
            ShuffleDeck();
            onGameGenerated.Raise();
        }

        public void ReturnCards()
        {
            PlayerHand.Instance.ReturnCardsToDeck();
            DealerHand.Instance.ReturnCardsToDeck();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        void GenerateDeck()
        {
            if (childCount != 0) { return; }

            foreach (CardData data in cardDataArray)
            {
                cardPrefab.GetComponent<Card>().cardData = data;
                InstantiateCardFromData(data);
            }
        }

        private void InstantiateCardFromData(CardData data)
        {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.parent = transform;
            newCard.transform.position = transform.position;
            newCard.name = data.name;
        }

        void ShuffleDeck()
        {
            int shuffleCount = 8;
            for (int i = 0; i < shuffleCount; i++)
            {
                foreach (Transform child in transform)
                {
                    child.SetSiblingIndex(Random.Range(0, transform.childCount));
                } 
            }
        }

        void DestroyAllCards()
        {
            Card[] gameCards = FindObjectsOfType<Card>();
            foreach (Card card in gameCards)
            {
                Destroy(card.gameObject);
            }
        }

        #endregion
    } 
}
