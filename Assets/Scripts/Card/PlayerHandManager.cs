using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerHandManager : CardCollectionBase
    {
        [SerializeField] List<CardDisplay> _cardDisplays;
        [SerializeField] PlayerDiscardManager _playerDiscard;
        public List<CardUISlot> CardSlots;
        
        public override bool AddCardToCollection(CardDisplay cardToAdd)
        {
            // find the first unoccupied slot to put the new card in
            CardUISlot targetSlot = CardSlots.FirstOrDefault(x => !x.IsOccupied);

            // do we have room in hand for this card?
            if (targetSlot != null)
            {
                // add data to list of cards in hand
                _cardDisplays.Add(cardToAdd);

                // tell the card's dragdrop where we are and allow dragging                
                CardDragDrop dragDrop = cardToAdd.GetComponent<CardDragDrop>();
                dragDrop.StartPos = cardToAdd.transform.position;
                dragDrop.CurrentSlot = targetSlot;
                dragDrop.AllowDragging = true;

                // tell the target slot about the card
                targetSlot.IsOccupied = true;
                targetSlot.DragDrop = dragDrop;
                targetSlot.CardDisplay = cardToAdd;

                // tell the card about the slot and arrange it on the screen
                cardToAdd.CurrentSlot = targetSlot;
                cardToAdd.transform.position = targetSlot.transform.position;
                cardToAdd.transform.SetParent(gameObject.transform);
                cardToAdd.gameObject.SetActive(true); // set active so the card is visible

                // little flip animation as it enters the hand
                cardToAdd.GetComponent<CardFlip>().FlipCard();

                return true;
            }
            else
                return false;
        }

        public override bool RemoveCardFromCollection(CardDisplay cardToRemove)
        {
            if (_cardDisplays.Contains(cardToRemove))
            {
                // remove the card from the hand slot, the hand data list, and send it to the discard pile
                cardToRemove.CurrentSlot.RemoveCardFromSlot();
                _cardDisplays.Remove(cardToRemove);

                // send the card to the discard pile
                _playerDiscard.AddCardToCollection(cardToRemove);

                return true;
            }
            else
                return false; // we did not remove anything
        }
    }
}