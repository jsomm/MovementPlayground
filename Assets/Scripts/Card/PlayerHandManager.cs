using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerHandManager : MonoBehaviour
    {
        public List<Card> HandCardInfo;
        public List<GameObject> HandCardObjects;

        [SerializeField] List<UICardSlot> _cardSlots;

        public bool AddCardToHand(Card cardToAdd, GameObject cardObject)
        {
            // find the first unoccupied slot to put the new card in
            UICardSlot targetSlot = _cardSlots.FirstOrDefault(x => !x.IsOccupied);

            // do we have room in hand for this card?
            if (targetSlot != null)
            {
                // add card data to the hand
                HandCardInfo.Add(cardToAdd);
                HandCardObjects.Add(cardObject);

                targetSlot.IsOccupied = true;
                cardObject.transform.position = targetSlot.transform.position;
                cardObject.transform.SetParent(gameObject.transform);
                
                // now that the card is in hand, enable dragging and flip it face up
                DragDrop dragDrop = cardObject.GetComponent<DragDrop>();
                dragDrop.StartPos = cardObject.transform.position;
                dragDrop.CurrentSlot = targetSlot.gameObject;
                dragDrop.AllowDragging = true;
                cardObject.GetComponent<CardFlip>().DrawFlip();

                return true;
            }
            else
                return false;
        }
    }
}