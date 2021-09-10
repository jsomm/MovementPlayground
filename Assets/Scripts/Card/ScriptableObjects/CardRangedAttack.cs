using UnityEngine;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New Ranged Attack Card", menuName = "Cards/Ranged Attack Card")]
    public class CardRangedAttack : CardBase
    {
        public GameObject ProjectilePrefab;
        public float ProjectileSpeed;

        public override void PlayCard(CardPlayer.CardPlayer cardPlayer)
        {
            Quaternion ninetyDegreeRotation = cardPlayer.ProjectileOrigin.transform.rotation * Quaternion.Euler(90, 0, 0); // just using this for my capsule prefab... probably wont need this for real prefabs
            GameObject projectile = Instantiate(ProjectilePrefab, cardPlayer.ProjectileOrigin.position, ninetyDegreeRotation, null);
            Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.velocity = cardPlayer.ProjectileOrigin.forward * ProjectileSpeed;
        }
    }
}
