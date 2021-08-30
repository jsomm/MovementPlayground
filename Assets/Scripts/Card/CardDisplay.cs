using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MovementPlayground.Card
{
    public class CardDisplay : MonoBehaviour
    {
        public Card card;

        public TMP_Text TitleText, DescriptionText, ResourceCost;
        public Image CardArt;

        public void DisplayCard()
        {
            TitleText.text = card.Title;
            DescriptionText.text = card.DescriptionText;
            ResourceCost.text = card.Cost.ToString();
            if (card.CardArt != null)
                CardArt.sprite = card.CardArt;
            else
                CardArt.gameObject.SetActive(false);
        }

    }
}