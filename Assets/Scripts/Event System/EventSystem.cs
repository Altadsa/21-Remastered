using System.Collections.Generic;
using UnityEngine;

namespace TwentyOneRemastered
{
    public class EventSystem : MonoBehaviour
    {
        [HideInInspector]
        public List<Listener> listeners = new List<Listener>();

        private void OnEnable()
        {
            foreach (var listener in listeners)
            {
                listener.Register();
            }
        }

        private void OnDisable()
        {
            foreach (var listener in listeners)
            {
                listener.Unregister();
            }
        }


    }
}
