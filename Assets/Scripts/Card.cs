using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        Event onCardFinishedMoving;

        public CardData cardData;

        string cardName;
        int cardValue;
        CardSuit suit;

        Transform parentTransform;
        bool isMoving;

        void OnEnable()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            MoveCardIfPossible();
        }

        private void MoveCardIfPossible()
        {
            if (isMoving)
            {
                parentTransform = transform.parent;
                transform.position = Vector3.Lerp(transform.position, parentTransform.position, 4.0f * Time.deltaTime);
                FinishCardMovement();
            }
        }

        private void FinishCardMovement()
        {
            if (Mathf.Abs(transform.position.y - parentTransform.position.y) < 0.5f)
            {
                transform.position = parentTransform.position;
                isMoving = false;
                onCardFinishedMoving.Raise();
            }
        }

        #region PUBLIC FUNCTIONS

        public void MoveCard() { isMoving = true; }

        #endregion

        #region PRIVATE FUNCTIONS

        void Initialize()
        {
            cardName = cardData.CardName;
            cardValue = cardData.Value;
            suit = cardData.CardSuit;
            if (cardData.CardSprite)
            {
                GetComponent<SpriteRenderer>().sprite = cardData.CardSprite;
            }
        }

        #endregion
    } 
}
