using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{

    [SerializeField]
    protected float fireRate = 0.5f;

    [SerializeField]
    protected GameObject Bullet;

    [SerializeField]
    protected float bulletPushForce = 12f;

    [SerializeField]
    protected Vector2 bulletDirection;

    protected float lastShot;

    protected virtual void HandleFire()
    {
        lastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.pushForce = bulletPushForce;
        bulletScript.pushDirection = bulletDirection;
        bullet.transform.position = gameObject.transform.position;
    }

    protected virtual bool IsReadyForFire()
    {
        return Time.time >= (lastShot + fireRate);
    }
}
