using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDeckManager : MonoBehaviour
    {
        public List<Card> DeckCardInfo;
        public List<GameObject> DeckCardObjects;        

        [SerializeField] GameObject _cardPrefab;
        [SerializeField] GameObject _deckSlot;
        [SerializeField] PlayerHandManager _playerHand;
        [SerializeField] TMP_Text _deckCountText;

        private void Start()
        {
            BuildTestDeck();
        }

        private void BuildTestDeck()
        {
            for (int i = 0; i < 10; i++)
            {
                Card card = ScriptableObject.CreateInstance<Card>();
                card.Title = "Test Title " + i.ToString();
                card.DescriptionText = "Test Desc " + i.ToString();
                card.Cost = UnityEngine.Random.Range(1, 10);
                DeckCardInfo.Add(card);
            }

            Shuffle();
            CreateAndStackCards();
        }
        public void Shuffle()
        {
            System.Random rng = new System.Random();
            int n = DeckCardInfo.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = DeckCardInfo[k];
                DeckCardInfo[k] = DeckCardInfo[n];
                DeckCardInfo[n] = value;
            }
        }

        void CreateAndStackCards()
        {
            // apply offset as we stack the cards so there's a 3d feel to the deck
            float cardPosOffset = 0f;
            foreach(Card card in DeckCardInfo)
            {
                GameObject newCard = CreateCardObject(card, _deckSlot.transform);
                DeckCardObjects.Add(newCard);
                newCard.transform.position += (Vector3)(Vector2.right * cardPosOffset);
                cardPosOffset += 4f;
            }

            // reverse the order so we appear to draw from the top to the bottom
            DeckCardInfo.Reverse();
            DeckCardObjects.Reverse();

            // set deck counter text
            UpdateDeckCount();
        }

        public GameObject CreateCardObject(Card cardData, Transform parent)
        {
            // create blank card
            GameObject newCard = Instantiate(_cardPrefab, parent.position, Quaternion.identity, parent);

            // feed card data to the display fields
            newCard.GetComponent<CardDisplay>().SetCard(cardData);

            return newCard;
        }

        public void Draw(int numberOfCardsToDraw)
        {
            // Draw as many cards as requested, unless that number exceeds the number of cards in the deck. If requesting more than is in the deck, just draw everything that is left in the deck.
            int cardsActuallyDrawn(int cardsRequested) => cardsRequested > DeckCardInfo.Count ? DeckCardInfo.Count : cardsRequested;
            for (int i = 0; i < cardsActuallyDrawn(numberOfCardsToDraw); i++)
            {
                if (_playerHand.AddCardToHand(DeckCardInfo[0], DeckCardObjects[0]))
                {
                    DeckCardInfo.RemoveAt(0);
                    DeckCardObjects.RemoveAt(0);
                    UpdateDeckCount();
                }
                else
                    break; // we've run out of room in the hand
            }
        }

        void UpdateDeckCount()
        {
            _deckCountText.text = DeckCardInfo.Count.ToString();
        }
    }
}