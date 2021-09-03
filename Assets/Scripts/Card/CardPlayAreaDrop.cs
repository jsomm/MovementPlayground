using UnityEngine;
using UnityEngine.EventSystems;

namespace MovementPlayground.Card
{
    public class CardPlayAreaDrop : MonoBehaviour, IDropHandler
    {
        [SerializeField] CardPlayer _cardPlayer;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                CardDisplay cardDisplay = eventData.pointerDrag.GetComponent<CardDisplay>();
                _cardPlayer.PlayCardInSlot(cardDisplay.CurrentSlot);
            }
        }
    }
}
