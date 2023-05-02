using UnityEngine;

public class EnemyLaserWeapon : WeaponScript
{
    [SerializeField]
    protected float attackTime = 1.5f;

    protected LaserScript laser;


    protected void Start()
    {
        lastShot = Time.time;
        GameObject bullet = Instantiate(Bullet);
        laser = bullet.GetComponent<LaserScript>();
    }

    protected void Update()
    {
        laser.transform.position = transform.position;
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override void HandleFire()
    {
        laser.StartAttack(attackTime);
        lastShot = Time.time;
    }

    public void ShootDown()
    {
        laser.ShutDown();
    }

}
