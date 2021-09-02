using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class CardPlayAreaDrop : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                CardDragDrop cardBeingDropped = eventData.pointerDrag.GetComponent<CardDragDrop>();
                if (cardBeingDropped.AllowDragging)
                {
                    // get the card's data
                    CardData cardData = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;
                    // play card stuff here
                    print("Dropped " + cardData.Title);
                }
            }
        }
    }
}
