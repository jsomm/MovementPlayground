using System.Collections;

namespace MovementPlayground.Card.CardPlayer
{
    public abstract class CardPlayerState
    {
        protected CardPlayer CardPlayer;

        public CardPlayerState(CardPlayer cardPlayer) => CardPlayer = cardPlayer;

        public virtual void Start()
        {
        }

        public virtual void AbilityButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
        }

        public virtual void MouseClicked(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
        }
    }
}
