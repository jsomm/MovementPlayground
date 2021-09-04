using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MovementPlayground.Card
{
    public class CardDisplay : MonoBehaviour
    {
        public CardBase CardData;
        public CardUISlot CurrentSlot;

        public TMP_Text TitleText, DescriptionText, ResourceCost;
        public Image CardArt;

        public void SetCardData(CardBase cardData)
        {
            CardData = cardData;
            DisplayCardData();
        }

        private void DisplayCardData()
        {
            TitleText.text = CardData.Title;
            DescriptionText.text = CardData.DescriptionText;
            ResourceCost.text = CardData.Cost.ToString();
            if (CardData.CardArt != null)
                CardArt.sprite = CardData.CardArt;
            else
                CardArt.gameObject.SetActive(false);
        }
    }
}