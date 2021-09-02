using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class CardUISlot : MonoBehaviour, IDropHandler
    {
        public bool IsOccupied = false;
        public CardDragDrop ObjectDroppedInSlot;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                ObjectDroppedInSlot = eventData.pointerDrag.GetComponent<CardDragDrop>();
                if (ObjectDroppedInSlot.AllowDragging)
                {
                    ObjectDroppedInSlot.DroppedOnSlot = true;
                    ObjectDroppedInSlot.CurrentSlot = gameObject;
                    ObjectDroppedInSlot.StartPos = transform.position;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                    if (ObjectDroppedInSlot.SlotAtStartOfDrag != null)
                        ObjectDroppedInSlot.SlotAtStartOfDrag.GetComponent<CardUISlot>().IsOccupied = false;

                    IsOccupied = true;
                }
            }
        }

        public void RemoveCardFromSlot()
        {
            IsOccupied = false;
            ObjectDroppedInSlot = null;
        }
    }
}