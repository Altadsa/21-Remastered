﻿using UnityEngine;

namespace TwentyOneRemastered
{
    public sealed class Deck : MonoBehaviour
    {

        const int DECK_SIZE = 10;

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

        #region UNITY LIFECYCLE

        void Start()
        {
            GenerateDeck();
            ShuffleDeck();
        } 

        #endregion

        #region PRIVATE FUNCTIONS

        void GenerateDeck()
        {
            foreach (CardData data in cardDataArray)
            {
                cardPrefab.GetComponent<Card>().cardData = data;
                GameObject newCard = Instantiate(cardPrefab);
                newCard.transform.parent = transform;
                newCard.name = data.name;
            }
        }

        void ShuffleDeck()
        {
            int shuffleCount = 3;
            for (int i = 0; i < shuffleCount; i++)
            {
                foreach (Transform child in transform)
                {
                    child.SetSiblingIndex(Random.Range(0, transform.childCount));
                } 
            }
        }

        #endregion
    } 
}
