using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class CardPlayArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public bool MouseIsInPlayArea;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                CardDisplay cardDisplay = eventData.pointerDrag.GetComponent<CardDisplay>();
                // TODO: Fix this to play the card correctly
                // _cardPlayer.PlayCardInSlot(cardDisplay.CurrentSlot);                
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            MouseIsInPlayArea = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MouseIsInPlayArea = false;
        }
    }
}
