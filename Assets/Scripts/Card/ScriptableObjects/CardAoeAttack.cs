using UnityEngine;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New AOE Attack Card", menuName = "Cards/AOE Attack Card")]
    public class CardAoeAttack : CardBase
    {
        public GameObject AoePrefab;

        public override void PlayCard(CardPlayer.CardPlayer cardPlayer)
        {
            Vector3 targetPosition = cardPlayer.TargetingManager.AoeIndicatorTransform.position;
            Instantiate(AoePrefab, targetPosition, Quaternion.identity, null);
        }
    }
}
