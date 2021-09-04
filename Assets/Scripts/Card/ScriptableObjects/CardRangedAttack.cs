using UnityEngine;

namespace MovementPlayground.Card
{
    [CreateAssetMenu(fileName = "New Ranged Attack Card", menuName = "Cards/Ranged Attack Card")]
    public class CardRangedAttack : CardBase
    {
        public GameObject ProjectilePrefab;
        public float ProjectileSpeed;

        public override void PlayCard(GameObject parent)
        {
            GameObject projectile = GameObject.Instantiate(ProjectilePrefab, parent.transform.position, Quaternion.identity, parent.transform);
            Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.velocity = parent.transform.forward * ProjectileSpeed;
        }
    }
}
