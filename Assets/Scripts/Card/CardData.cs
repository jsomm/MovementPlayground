using UnityEngine;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data")]
    public class CardData : ScriptableObject
    {
        public string Title, DescriptionText;
        public int Cost;
        public Sprite CardArt;
    }
}