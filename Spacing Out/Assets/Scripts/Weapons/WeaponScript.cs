using UnityEngine;

public abstract class WeaponScript : MonoBehaviour, IFreezable
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

    protected float bulletDamage = 1f;

    protected virtual void HandleFire()
    {
        lastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Damage = bulletDamage;
        bulletScript.pushForce = bulletPushForce;
        bulletScript.pushDirection = bulletDirection;
        bullet.transform.position = gameObject.transform.position;
    }

    protected virtual bool IsReadyForFire()
    {
        return Time.time >= (lastShot + fireRate);
    }

    public void Freeze(float freezeTime)
    {
        lastShot = lastShot + freezeTime;
    }

    public void SetNewShotSpeed(float newShotSpeed)
    {
        lastShot = Time.time;
        fireRate = newShotSpeed;
    }

    public void SetNewDamage(float Damage)
    {
        bulletDamage = Damage;
    }
}
