using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDeckManager : CardCollectionBase
    {
        [SerializeField] List<CardDisplay> _cardDisplays;
        [SerializeField] List<GameObject> _cardPrefabs;
        [SerializeField] Transform _deckDataHolder;
        [SerializeField] TMP_Text _deckCountText;

        [SerializeField] PlayerHandManager _playerHand;
        [SerializeField] PlayerDiscardManager _playerDiscard;

        System.Random _rng;

        private void Start()
        {
            _rng = new System.Random();
            BuildTestDeck();
        }

        void BuildTestDeck()
        {
            CardCreator cardCreator = new CardCreator();
            int remainder = 10 % _cardPrefabs.Count;
            int numOfEachCard = 10 / _cardPrefabs.Count;
            int numCreated = 0;
            int currentCardIndex = 0;

            // create a ten card deck out of the cards in _cardPrefabs
            for (int i = 0; i < 10; i++)
            {
                GameObject newCard;

                // make the remainders first
                if (i < remainder)
                    newCard = cardCreator.CreateCardObject(_cardPrefabs[_rng.Next(_cardPrefabs.Count)], _deckDataHolder); // remainders will just be randomized from all available cards
                else
                {
                    if(numCreated != numOfEachCard)                    
                        numCreated++;                    
                    else
                    {
                        numCreated = 0;
                        currentCardIndex++;
                    }
                    newCard = cardCreator.CreateCardObject(_cardPrefabs[currentCardIndex], _deckDataHolder);
                }

                // add data to collection
                AddCardToCollection(newCard.GetComponent<CardDisplay>());
            }

            Shuffle();
        }

        public void Shuffle()
        {
            int n = _cardDisplays.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                CardDisplay value = _cardDisplays[k];
                _cardDisplays[k] = _cardDisplays[n];
                _cardDisplays[n] = value;
            }
        }

        public void Draw(int numberOfCardsToDraw)
        {
            if(numberOfCardsToDraw > _cardDisplays.Count) // the player wants to draw more than we have in the deck
            {
                if (_cardDisplays.Count > 0) // we still have cards for them to draw before we shuffle in the discard
                {
                    numberOfCardsToDraw -= _cardDisplays.Count;
                    Draw(_cardDisplays.Count); // draw the rest in the deck                
                }

                // now shuffle in the discard pile
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