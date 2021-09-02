using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerHandManager : MonoBehaviour
    {
        public List<CardData> HandCardInfo;
        public List<GameObject> HandCardObjects;
        public List<CardUISlot> CardSlots;

        public bool AddCardToHand(CardData cardToAdd, GameObject cardObject)
        {
            // find the first unoccupied slot to put the new card in
            CardUISlot targetSlot = CardSlots.FirstOrDefault(x => !x.IsOccupied);

            // do we have room in hand for this card?
            if (targetSlot != null)
            {
                // add card data to the hand
                HandCardInfo.Add(cardToAdd);
                HandCardObjects.Add(cardObject);

                targetSlot.IsOccupied = true;
                targetSlot.ObjectDroppedInSlot = cardObject.GetComponent<CardDragDrop>();
                cardObject.transform.position = targetSlot.transform.position;
                cardObject.transform.SetParent(gameObject.transform);
                
                // now that the card is in hand, enable dragging and flip it face up
                CardDragDrop dragDrop = cardObject.GetComponent<CardDragDrop>();
                dragDrop.StartPos = cardObject.transform.position;
                dragDrop.CurrentSlot = targetSlot.gameObject;
                dragDrop.AllowDragging = true;
                cardObject.GetComponent<CardFlip>().DrawFlip();

                return true;
            }
            else
                return false;
        }

        public void RemoveCardFromHand(CardUISlot slotWithCardToRemove)
        {
            // get game object of card being removed
            GameObject cardObject = slotWithCardToRemove.ObjectDroppedInSlot.gameObject;

            // remove card data from hand
            HandCardInfo.Remove(cardObject.GetComponent<CardDisplay>().CardData);
            HandCardObjects.Remove(cardObject);

            // TODO: send card to discard pile before deleting data from hand

            // for now destroy the object... later we will store in discard so we can just reuse the same object
            Destroy(cardObject);

            // remove card from slot
            slotWithCardToRemove.RemoveCardFromSlot();
        }
    }
}