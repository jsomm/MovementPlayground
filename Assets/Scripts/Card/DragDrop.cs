using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        Canvas _canvas;
        CanvasGroup _canvasGroup;
        RectTransform _rectTransform;
        public Vector2 StartPos;
        public bool DroppedOnSlot;
        public GameObject CurrentSlot, SlotAtStartOfDrag;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
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
            _canvasGroup.blocksRaycasts = false;
            if(CurrentSlot != null)
                SlotAtStartOfDrag = CurrentSlot;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            if (DroppedOnSlot == false)
            {
                transform.position = StartPos;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }
}