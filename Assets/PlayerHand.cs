using UnityEngine;

namespace TwentyOneRemastered
{
    public class PlayerHand : MonoBehaviour
    {

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
                Deck.Instance.transform.GetChild(0).transform.parent = transform;
            }

        }
    } 
}
