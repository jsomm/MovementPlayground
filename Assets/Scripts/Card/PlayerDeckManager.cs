using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDeckManager : MonoBehaviour
    {
        public List<CardData> DeckCardData;
        public List<GameObject> DeckCardObjects;        

        [SerializeField] GameObject _cardPrefab;
        [SerializeField] GameObject _deckSlot;
        [SerializeField] PlayerHandManager _playerHand;
        [SerializeField] TMP_Text _deckCountText;

        private void Start() => BuildTestDeck();

        private void BuildTestDeck()
        {
            for (int i = 0; i < 10; i++)
            {
                CardData card = ScriptableObject.CreateInstance<CardData>();
                card.Title = "Test Title " + i.ToString();
                card.DescriptionText = "Test Desc " + i.ToString();
                card.Cost = UnityEngine.Random.Range(1, 10);
                DeckCardData.Add(card);
            }

            Shuffle();
            CreateAndStackCards();
        }
        public void Shuffle()
        {
            System.Random rng = new System.Random();
            int n = DeckCardData.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CardData value = DeckCardData[k];
                DeckCardData[k] = DeckCardData[n];
                DeckCardData[n] = value;
            }
        }

        void CreateAndStackCards()
        {
            // apply offset as we stack the cards so there's a 3d feel to the deck
            float cardPosOffset = 0f;
            CardCreator cardCreator = new CardCreator();
            foreach(CardData card in DeckCardData)
            {
                GameObject newCard = cardCreator.CreateCardObject(_cardPrefab, card, _deckSlot.transform);
                DeckCardObjects.Add(newCard);
                newCard.transform.position += (Vector3)(Vector2.right * cardPosOffset);
                if(cardPosOffset < 40f)
                    cardPosOffset += 4f;
            }

            // reverse the order so we appear to draw from the top to the bottom
            DeckCardData.Reverse();
            DeckCardObjects.Reverse();

            // set deck counter text
            UpdateDeckCount();
        }

        public void Draw(int numberOfCardsToDraw)
        {
            // Draw as many cards as requested, unless that number exceeds the number of cards in the deck. If requesting more than is in the deck, just draw everything that is left in the deck.
            int cardsActuallyDrawn(int cardsRequested) => cardsRequested > DeckCardData.Count ? DeckCardData.Count : cardsRequested;
            for (int i = 0; i < cardsActuallyDrawn(numberOfCardsToDraw); i++)
            {
                if (_playerHand.AddCardToHand(DeckCardData[0], DeckCardObjects[0]))
                {
                    DeckCardData.RemoveAt(0);
                    DeckCardObjects.RemoveAt(0);
                    UpdateDeckCount();
                }
                else
                    break; // we've run out of room in the hand
            }
        }

        void UpdateDeckCount() => _deckCountText.text = DeckCardData.Count.ToString();
    }
}