using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementPlayground.Card.CardPlayer
{
    public class CardSelected : CardPlayerState
    {
        CardBase _selectedCardData;

        public CardSelected(CardPlayer cardPlayer) : base(cardPlayer)
        {
        }

        public override void Start()
        {
            // get the data for the selected card so we can use it later when we actually play it
            _selectedCardData = CardPlayer.LastSlotPressed.CardDisplay.CardData;

            // TODO: activate some kind of effect on the last slot pressed to indicate what card is selected

            // display targeting indicators for the selected card
            CardPlayer.TargetingManager.ShowIndicatorForCard(_selectedCardData);
        }

        public override void AbilityButtonPressed(InputAction.CallbackContext obj)
        {
            // check if the button pressed matches the slot we had previously selected            
            if(CardPlayer.LastSlotPressed == CardPlayer.DetermineSlotFromKeybindName(obj.action.name))
            {
                // play the card
                if (CanPlayCardInSlot(CardPlayer.LastSlotPressed))
                    PlayCardInSlot();
            }
            // either we played the card or the user pressed a different button than initially pressed, so lets go back to normal gameplay state
            CardPlayer.SetState(new Gameplay(CardPlayer));
        }

        public override void MouseClicked(InputAction.CallbackContext obj)
        {
            // if the mouse is in the play area and the player has enough mana, play the card
            if (CardPlayer.CardPlayArea.MouseIsInPlayArea && CanPlayCardInSlot(CardPlayer.LastSlotPressed))
                PlayCardInSlot();

            // back to normal gameplay
            CardPlayer.SetState(new Gameplay(CardPlayer));
        }

        private bool CanPlayCardInSlot(CardUISlot slot)
        {
            // if we have enough mana for the card return true
            if (CardPlayer.ResourceBarManager.CurrentMana >= slot.CardDisplay.CardData.Cost)
                return true;
            else
            {
                Debug.Log("Not enough mana!");
                return false;
            }
        }

        private void PlayCardInSlot()
        {
            // get info needed to play the card
            CardBase cardData = CardPlayer.LastSlotPressed.CardDisplay.CardData;

            // use mana
            CardPlayer.ResourceBarManager.ChangeResource(CardPlayer.ResourceBarManager.ManaBar, cardData.Cost);

            // play the card
            cardData.PlayCard(CardPlayer);

            // remove the card from the hand
            CardPlayer.PlayerHandManager.RemoveCardFromCollection(CardPlayer.LastSlotPressed.CardDisplay);
        }
    }
}
