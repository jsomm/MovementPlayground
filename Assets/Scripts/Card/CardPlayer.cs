using System;

using MovementPlayground.ResourceBars;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class CardPlayer : MonoBehaviour
    {
        public delegate void StartPlayingCardAction(CardBase card); // not totally sure how to use these just yet.. the fact that they are staying in is just a reminder for me to get to work on this...
        public static event StartPlayingCardAction OnStartPlayingCard;

        public delegate void CardPlayedAction(CardBase card);
        public static event CardPlayedAction OnCardPlayed;

        [SerializeField] PlayerHandManager _playerHand;

        PlayerInput _playerInput;
        ResourceBarManager _resourceBarManager;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _resourceBarManager = GameObject.Find("Resource Bars").GetComponent<ResourceBarManager>();
        }

        private void OnEnable()
        {
            _playerInput.CharacterControls.Enable(); 
            _playerInput.CharacterControls.AbilityOne.performed += PlayCard;
            _playerInput.CharacterControls.AbilityTwo.performed += PlayCard;
            _playerInput.CharacterControls.AbilityThree.performed += PlayCard;
            _playerInput.CharacterControls.AbilityFour.performed += PlayCard;
        }

        private void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
            _playerInput.CharacterControls.AbilityOne.performed -= PlayCard;
            _playerInput.CharacterControls.AbilityTwo.performed -= PlayCard;
            _playerInput.CharacterControls.AbilityThree.performed -= PlayCard;
            _playerInput.CharacterControls.AbilityFour.performed -= PlayCard;
        }

        private void PlayCard(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            // determine the card slot we're playing from
            CardUISlot slotBeingPlayed = DetermineSlot(obj.action.name);
            PlayCardInSlot(slotBeingPlayed);
        }

        private CardUISlot DetermineSlot(string actionName)
        {
            switch (actionName)
            {
                case "AbilityOne":
                    return _playerHand.CardSlots[0];
                case "AbilityTwo":
                    return _playerHand.CardSlots[1];
                case "AbilityThree":
                    return _playerHand.CardSlots[2];
                case "AbilityFour":
                    return _playerHand.CardSlots[3];
                default:
                    break;
            }

            return null;
        }

        public void PlayCardInSlot(CardUISlot slotToPlay)
        {
            // if there's a card in the slot
            if (slotToPlay.IsOccupied)
            {
                // get info needed to play the card
                CardDisplay cardDisplay = slotToPlay.CardDisplay;
                CardBase cardData = cardDisplay.CardData;

                // play the card
                if (_resourceBarManager.CurrentMana >= cardData.Cost)
                {
                    print("Played " + cardData.Title + " for " + cardData.Cost + " resource. " + cardData.DescriptionText);
                    _resourceBarManager.UseMana(cardData.Cost);
                    cardData.PlayCard(gameObject);
                    OnCardPlayed.Invoke(cardData);

                    // remove the card from the hand
                    _playerHand.RemoveCardFromCollection(cardDisplay);
                }
                else
                    print("Not enough mana!");
            }
        }
    }
}
