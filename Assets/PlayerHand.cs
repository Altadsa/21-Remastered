using System.Collections;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {

        int handValue;

        float padding = 0.2f;

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.A) && Deck.Instance.transform.childCount > 0)
            {
                AddCardToHand();
                SetOrderInLayer();
                Debug.Log(handValue);
            }
            foreach (Transform child in transform)
            {
                AdjustCards(child);
            }
        }

        private void AddCardToHand()
        {
            Transform deckCard = Deck.Instance.transform.GetChild(0);
            deckCard.transform.position = Vector3.Lerp(deckCard.transform.position, transform.position, 1.0f * Time.deltaTime);
            handValue += deckCard.GetComponent<Card>().cardData.Value;
            deckCard.transform.parent = transform;
        }

        private void AdjustCards(Transform child)
        {
            Vector2 childPos = child.position;
            Vector2 newPos = new Vector2(transform.position.x + padding, transform.position.y);
            child.position = Vector3.Lerp(child.position, newPos, 2.0f * Time.deltaTime);
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
    } 
}
