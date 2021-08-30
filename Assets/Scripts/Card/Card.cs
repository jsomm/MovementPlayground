using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string Title, DescriptionText;
        public int Cost;
        public Sprite CardArt;
    }
}