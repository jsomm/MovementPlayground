using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDiscardManager : CardCollectionBase
    {
        [SerializeField] List<CardDisplay> _cardDisplays;
        [SerializeField] Transform _discardDataHolder;
        [SerializeField] TMP_Text _discardCountText;

        private void Start()
        {
            UpdateCardCount();
        }

        public override bool AddCardToCollection(CardDisplay cardToAdd)
        {
            // add card data
            _cardDisplays.Add(cardToAdd);

            // set parent for organization
            cardToAdd.gameObject.transform.SetParent(_discardDataHolder);

            // flip card to back side and disable to hide from the UI
            CardFlip flip = cardToAdd.GetComponent<CardFlip>();
            if (flip.IsFaceUp)
                flip.FlipCard();
            cardToAdd.gameObject.SetActive(false);

            UpdateCardCount();

            return true;
        }
        public override bool RemoveCardFromCollection(CardDisplay cardToRemove)
        {
            if (_cardDisplays.Contains(cardToRemove))
            {
                _cardDisplays.Remove(cardToRemove);
                UpdateCardCount();
                return true;
            }
            else
                return false; // we couldn't find the card
        }

        void UpdateCardCount() => _discardCountText.text = _cardDisplays.Count.ToString();

        public List<CardDisplay> ReturnCardsToDeck()
        {
            List<CardDisplay> cardReturnList = _cardDisplays.GetRange(0, _cardDisplays.Count); // clone the list so we can remove all the old elements and still return them to the deck
            foreach (CardDisplay card in cardReturnList)
                RemoveCardFromCollection(card);

            return cardReturnList;
        }
    }
}
