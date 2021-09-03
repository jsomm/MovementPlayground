using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class CardUISlot : MonoBehaviour, IDropHandler
    {
        public bool IsOccupied = false;
        public CardDragDrop DragDrop;
        public CardDisplay CardDisplay;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                DragDrop = eventData.pointerDrag.GetComponent<CardDragDrop>();
                CardDisplay = eventData.pointerDrag.GetComponent<CardDisplay>();
                CardDisplay.CurrentSlot = this;
                if (DragDrop.AllowDragging)
                {
                    DragDrop.DroppedOnSlot = true;
                    DragDrop.CurrentSlot = this;
                    DragDrop.StartPos = transform.position;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                    if (DragDrop.SlotAtStartOfDrag != null)
                        DragDrop.SlotAtStartOfDrag.GetComponent<CardUISlot>().IsOccupied = false;

                    IsOccupied = true;
                }
            }
        }

        public void RemoveCardFromSlot()
        {
            IsOccupied = false;
            DragDrop = null;
            CardDisplay = null;
        }
    }
}