using MovementPlayground.Card;

using UnityEngine;

namespace MovementPlayground
{
    public class CardCreator
    {

        public GameObject CreateCardObject(GameObject prefab, Transform parent)
        {
            // create blank card
            GameObject newCard = GameObject.Instantiate(prefab, parent.position, Quaternion.identity, parent);

            // feed card data to the display fields
            newCard.GetComponent<CardDisplay>().DisplayCardData();

            return newCard;
        }
    }
}
