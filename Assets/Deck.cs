using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class Deck : MonoBehaviour
    {

        const int DECK_SIZE = 10;

        [SerializeField]
        GameObject cardPrefab;

        [SerializeField]
        CardData[] cardDataArray;

        #region UNITY LIFECYCLE

        void Start()
        {
            GenerateDeck();
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

        #endregion
    } 
}
