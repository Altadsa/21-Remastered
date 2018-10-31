using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        Event onGameStarted;

        public void OnGameGenerated()
        {
            onGameStarted.Raise();
        }

    } 
}
