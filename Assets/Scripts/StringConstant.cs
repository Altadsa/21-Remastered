using UnityEngine;

namespace TwentyOneRemastered
{
    [CreateAssetMenu(menuName = "21/Constants/String")]
    public class StringConstant : ScriptableObject
    {
        [TextArea(1, 5)]
        [SerializeField]
        string value;

        public string Value { get { return value; } }

    } 
}
