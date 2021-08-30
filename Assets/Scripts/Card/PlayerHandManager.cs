using System.Collections.Generic;
using System.Linq;

using UnityEngine;


namespace MovementPlayground.Card
{
    public class PlayerHandManager : MonoBehaviour
    {
        public List<Card> PlayerHand;

        [SerializeField] GameObject CardPrefab;
        [SerializeField] List<UICardSlot> CardSlots;

        public bool AddCardToHand(Card cardToAdd)
        {
            // find the first unoccupied slot to put the new card in
            UICardSlot targetSlot = CardSlots.FirstOrDefault(x => !x.IsOccupied);

            // do we have room in hand for this card?
            if (targetSlot != null)
            {
                // add card data to the hand
                PlayerHand.Add(cardToAdd);

                targetSlot.IsOccupied = true;
                GameObject newCard = Instantiate(CardPrefab, targetSlot.transform.position, Quaternion.identity, gameObject.transform);
                newCard.GetComponent<DragDrop>().CurrentSlot = targetSlot.gameObject;

                // feed card data to the display fields
                CardDisplay display = newCard.GetComponent<CardDisplay>();
                display.card = cardToAdd;
                display.DisplayCard();
                return true;
            }
            else
                return false;
        }
    }
}