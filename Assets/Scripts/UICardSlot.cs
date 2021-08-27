using UnityEngine;
using UnityEngine.EventSystems;

public class UICardSlot : MonoBehaviour, IDropHandler
{
    public bool IsOccupied;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().DroppedOnSlot = true;
            eventData.pointerDrag.GetComponent<DragDrop>().StartPos = transform.position;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
