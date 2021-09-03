using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDeckManager : CardCollectionBase
    {
        [SerializeField] List<CardDisplay> _cardDisplays;
        [SerializeField] GameObject _cardPrefab;
        [SerializeField] Transform _deckDataHolder;
        [SerializeField] TMP_Text _deckCountText;

        [SerializeField] PlayerHandManager _playerHand;
        [SerializeField] PlayerDiscardManager _playerDiscard;

        private void Start() => BuildTestDeck();

        void BuildTestDeck()
        {
            CardCreator cardCreator = new CardCreator();
            for (int i = 0; i < 10; i++)
            {
                // make up some card data
                CardData cardData = ScriptableObject.CreateInstance<CardData>();
                cardData.Title = "Test Title " + i.ToString();
                cardData.DescriptionText = "Test Desc " + i.ToString();
                cardData.Cost = UnityEngine.Random.Range(1, 10);

                // create a card with that data
                GameObject newCard = cardCreator.CreateCardObject(_cardPrefab, cardData, _deckDataHolder);

                // add data to collection
                AddCardToCollection(newCard.GetComponent<CardDisplay>());
            }

            Shuffle();
        }

        public void Shuffle()
        {
            System.Random rng = new System.Random();
            int n = _cardDisplays.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CardDisplay value = _cardDisplays[k];
                _cardDisplays[k] = _cardDisplays[n];
                _cardDisplays[n] = value;
            }
        }

        public void Draw(int numberOfCardsToDraw)
        {
            // TODO: If there are still cards in the deck and the player wants more than that number of cards, this doesn't work!
            if(numberOfCardsToDraw > _cardDisplays.Count) // the player wants to draw more than we have in the deck
            {
                _cardDisplays = _playerDiscard.ReturnCardsToDeck();
                Shuffle();
                UpdateCardCount();
            }

            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                if (_playerHand.AddCardToCollection(_cardDisplays[0])) // if we successfully add the card to the player's hand
                {
                    RemoveCardFromCollection(_cardDisplays[0]);
                    UpdateCardCount();
                }
                else
                    break; // we've run out of room in the hand
            }
        }

        void UpdateCardCount() => _deckCountText.text = _cardDisplays.Count.ToString();

        public override bool AddCardToCollection(CardDisplay cardToAdd)
        {
            // add card data
            _cardDisplays.Add(cardToAdd);

            // hide the card from the UI
            cardToAdd.gameObject.SetActive(false);

            // set deck counter text
            UpdateCardCount();

            return true;
        }

        public override bool RemoveCardFromCollection(CardDisplay cardToRemove)
        {
            _cardDisplays.Remove(cardToRemove);
            UpdateCardCount();
            return true;
        }
    }
}