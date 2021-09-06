using UnityEngine;

namespace MovementPlayground.Card
{
    public class CardSOTesterUtility : MonoBehaviour
    {
        // TO USE: create a card prefab and add this script to it. Then add the scriptable object you want to test with to THIS COMPONENT. The rest will be taken care of when the game starts. Do not flip the card or anything, this takes care of that.

        public CardBase CardData;
        private void Awake()
        {
            CardDisplay cd = GetComponent<CardDisplay>();            
            cd.SetCardData(CardData);

            PlayerHandManager playerHand = GameObject.Find("PlayerHand").GetComponent<PlayerHandManager>();
            playerHand.AddCardToCollection(cd);
        }
    }
}
