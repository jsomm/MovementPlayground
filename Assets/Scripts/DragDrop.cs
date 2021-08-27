using UnityEngine;
using UnityEngine.EventSystems;

using static UnityEditorInternal.ReorderableList;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    public Vector2 StartPos;
    public bool DroppedOnSlot;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        StartPos = transform.position;
    }
    private void Start()
    {
        StartPos = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragDrop>().DroppedOnSlot = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (DroppedOnSlot == false)
        {
            transform.position = StartPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
