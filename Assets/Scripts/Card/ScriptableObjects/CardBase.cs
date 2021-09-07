using UnityEngine;

namespace MovementPlayground.Card
{
    public class CardBase : ScriptableObject
    {
        public string Title, DescriptionText;
        public int Cost;
        public Sprite CardArt;
        public CardIndicatorType IndicatorType;

        public enum CardIndicatorType
        {
            Skillshot,
            AOE
        }

        public virtual void PlayCard(GameObject parent) { }
    }
}