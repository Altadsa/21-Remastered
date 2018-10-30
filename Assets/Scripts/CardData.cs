using UnityEngine;

namespace TwentyOneRemastered
{
    public enum CardSuit
    {
        CLUBS,
        DIAMONDS,
        HEARTS,
        SPADES
    }

    [CreateAssetMenu(menuName = "21/Card Data")]
    public class CardData : ScriptableObject
    {

        #region VALUES

        [SerializeField]
        string cardName;

        [SerializeField]
        int value;

        [SerializeField]
        Sprite cardSprite;

        [SerializeField]
        CardSuit cardSuit;

        #endregion

        #region PROPERTIES

        public string CardName { get { return cardName; } }
        public int Value { get { return value; } }
        public Sprite CardSprite { get { return cardSprite; } } 

        #endregion

    } 
}
