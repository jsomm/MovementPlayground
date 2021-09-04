using UnityEngine;

namespace MovementPlayground.Card
{
    public class CardSOTesterUtility : MonoBehaviour
    {
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
