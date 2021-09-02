using System;

using UnityEngine;

namespace MovementPlayground.Card
{
    public class CardPlayer : MonoBehaviour
    {
        [SerializeField] PlayerHandManager _playerHand;

        PlayerAnimationAndMovementController _playerController; // maybe need this?
        PlayerInput _playerInput;

        private void Awake()
        {
            _playerController = GetComponent<PlayerAnimationAndMovementController>();
            _playerInput = new PlayerInput();
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

            // if there's a card in the slot
            if (slotBeingPlayed.IsOccupied)
            {
                // get info needed to play the card
                CardData cardData = slotBeingPlayed.ObjectDroppedInSlot.GetComponent<CardDisplay>().CardData;

                // play the card
                print("Played " + cardData.Title + " for " + cardData.Cost + " resource. " + cardData.DescriptionText);

                // remove the card from the hand
                _playerHand.RemoveCardFromHand(slotBeingPlayed);
            }
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
    }
}
