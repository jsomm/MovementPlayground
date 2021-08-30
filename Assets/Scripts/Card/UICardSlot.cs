using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class UICardSlot : MonoBehaviour, IDropHandler
    {
        public bool IsOccupied = false;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                DragDrop itemBeingDropped = eventData.pointerDrag.GetComponent<DragDrop>();
                itemBeingDropped.DroppedOnSlot = true;
                itemBeingDropped.CurrentSlot = gameObject;
                itemBeingDropped.StartPos = transform.position;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                if(itemBeingDropped.SlotAtStartOfDrag != null)
                    itemBeingDropped.SlotAtStartOfDrag.GetComponent<UICardSlot>().IsOccupied = false;

                IsOccupied = true;
            }
        }
    }
}