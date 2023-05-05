using UnityEngine;

public class EnemyLaserWeapon : WeaponScript
{
    [SerializeField]
    protected float attackTime = 1.5f;

    protected LaserScript laser;

    private SoundController sc;

    protected void Start()
    {
        lastShot = Time.time;
        GameObject bullet = Instantiate(Bullet);
        laser = bullet.GetComponent<LaserScript>();
        sc = FindObjectOfType<SoundController>();
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
        sc.SmallLaser();
        laser.StartAttack(attackTime);
        lastShot = Time.time;
    }

    private void OnDestroy()
    {
        if(laser != null)
            Destroy(laser.gameObject);
    }

}
