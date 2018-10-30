using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {

        int handValue;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.A) && Deck.Instance.transform.childCount > 0)
            {
                Deck.Instance.transform.GetChild(0).transform.position = transform.position;
                handValue += Deck.Instance.transform.GetChild(0).GetComponent<Card>().cardData.Value;
                Deck.Instance.transform.GetChild(0).transform.parent = transform;
                Debug.Log(handValue);
            }

        }
    } 
}
