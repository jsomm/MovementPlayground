using UnityEngine;

[CreateAssetMenu]
public class ShootCapsule : Ability
{
    public GameObject Projectile;
    public float ProjectileVelocity = 50f;

    public override void Activate(GameObject parent)
    {
        Transform projectileOrigin = parent.transform.Find("ProjectileOrigin");
        GameObject createdProjectile = Instantiate(Projectile, projectileOrigin.position, projectileOrigin.rotation);
        createdProjectile.GetComponent<Rigidbody>().velocity = projectileOrigin.transform.forward * ProjectileVelocity;
    }
}
