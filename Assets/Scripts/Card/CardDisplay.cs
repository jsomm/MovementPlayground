using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MovementPlayground.Card
{
    public class CardDisplay : MonoBehaviour
    {
        public Card Card;

        public TMP_Text TitleText, DescriptionText, ResourceCost;
        public Image CardArt;

        public void DisplayCard()
        {
            TitleText.text = Card.Title;
            DescriptionText.text = Card.DescriptionText;
            ResourceCost.text = Card.Cost.ToString();
            if (Card.CardArt != null)
                CardArt.sprite = Card.CardArt;
            else
                CardArt.gameObject.SetActive(false);
        }
    }
}