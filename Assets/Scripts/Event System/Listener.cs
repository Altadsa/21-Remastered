using UnityEngine.Events;

namespace TwentyOneRemastered
{
    [System.Serializable]
    public class Listener
    {

        public Event _Event;

        public UnityEvent response;

        public void Register()
        {
            _Event.RegisterListener(this);
        }

        public void Unregister()
        {
            _Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}
