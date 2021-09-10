using UnityEngine;

namespace MovementPlayground.Card.CardPlayer
{
    public abstract class CardPlayerStateMachine : MonoBehaviour
    {
        protected CardPlayerState State;

        public void SetState(CardPlayerState state)
        {
            State = state;
            State.Start();
        }
    }
}
