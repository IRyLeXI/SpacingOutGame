using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{

    [SerializeField]
    protected float FireRate = 0.5f;

    [SerializeField]
    protected GameObject Bullet;

    [SerializeField]
    protected float BulletPushForce = 12f;

    [SerializeField]
    protected Vector2 BulletDirection;

    protected float LastShot;

    protected virtual void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.pushForce = BulletPushForce;
        bulletScript.pushDirection = BulletDirection;
        bullet.transform.position = gameObject.transform.position;
    }

    protected virtual bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate);
    }
}
