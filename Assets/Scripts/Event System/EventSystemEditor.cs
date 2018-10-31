using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;


namespace TwentyOneRemastered
{
    [CustomEditor(typeof(EventSystem))]
    public class EventSystemEditor : Editor
    {

        EventSystem eventSystem;
        SerializedProperty listeners;

        Event assignedEvent;

        private void Awake()
        {
            eventSystem = (EventSystem)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawEventAssignment();
        }

        void DrawEventAssignment()
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Add Event");
            assignedEvent = (Event)EditorGUILayout.ObjectField(
                assignedEvent, typeof(Event), false);
            if (GUILayout.Button("Add"))
            {
                if (assignedEvent)
                {
                    CreateListener(assignedEvent);
                    assignedEvent = null;
                }
            }
            GUILayout.EndVertical();
        }

        void CreateListener(Event _event)
        {
            Listener listener = new Listener
            {
                _Event = _event
            };
            eventSystem.listeners.Add(listener);
        }
    }
}
#endif
