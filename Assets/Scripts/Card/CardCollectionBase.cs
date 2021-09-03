using System.Collections.Generic;

using UnityEngine;

namespace MovementPlayground.Card
{
    public abstract class CardCollectionBase : MonoBehaviour
    {
        public abstract bool AddCardToCollection(CardDisplay cardToAdd);
        public abstract bool RemoveCardFromCollection(CardDisplay cardToRemove);
    }
}
