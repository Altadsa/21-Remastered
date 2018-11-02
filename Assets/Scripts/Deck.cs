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

        const int DECK_SIZE = 10;

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

        #region UNITY LIFECYCLE

        void OnEnable()
        {
            GenerateDeck();
            ShuffleDeck();
            onGameGenerated.Raise();
        }

        private void OnDisable()
        {
            DestroyAllCards();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        void GenerateDeck()
        {
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
