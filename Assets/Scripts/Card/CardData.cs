using UnityEngine;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data")]
    public class CardData : CardBase
    {
        public string Title, DescriptionText;
        public int Cost;
        public Sprite CardArt;

        public override void PlayCard()
        {
            throw new System.NotImplementedException();
        }
    }
}