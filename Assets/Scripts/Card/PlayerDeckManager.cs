using System;
using System.Collections.Generic;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class PlayerDeckManager : MonoBehaviour
    {
        public List<Card> Deck;

        [SerializeField] PlayerHandManager playerHand;

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
                Deck.Add(card);
            }

            Shuffle();
        }

        public void Shuffle()
        {
            System.Random rng = new System.Random();
            int n = Deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = value;
            }
        }

        public void Draw(int numberOfCardsToDraw)
        {
            // Draw as many cards as requested, unless that number exceeds the number of cards in the deck. If requesting more than is in the deck, just draw everything that is left in the deck.
            int cardsActuallyDrawn(int cardsRequested) => cardsRequested > Deck.Count ? Deck.Count : cardsRequested; 
            for (int i = 0; i < cardsActuallyDrawn(numberOfCardsToDraw); i++)
            {
                if (playerHand.AddCardToHand(Deck[0]))
                    Deck.RemoveAt(0);
                else
                    break; // we've run out of room in the hand
            }
            
        }
    }
}