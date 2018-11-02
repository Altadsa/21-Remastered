using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class AceHandler : MonoBehaviour
    {
        public int secondHandValue = 0;

        public void Initialize()
        {
            int firstHandValue = GetComponent<Hand>().HandValue;
            secondHandValue = firstHandValue + 10;
            Debug.Log(string.Format("First Hand: {0}, Second Hand: {1}", firstHandValue, secondHandValue));
        }
    } 
}
