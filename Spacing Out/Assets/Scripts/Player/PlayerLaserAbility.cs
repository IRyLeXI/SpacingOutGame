using UnityEngine;

public class PlayerLaserAbility : WeaponScript
{

    [SerializeField]
    protected float attackTime = 1.5f;

    protected LaserScript laser;

    private SoundController sc;

    protected void Start()
    {
        lastShot = Time.time - fireRate;
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
        if(Input.GetButton("Special"))
        {
            sc.SmallLaser();
            laser.StartAttack(attackTime);
            lastShot = Time.time;
        }
    }

    public void ShootDown()
    {
        laser.ShutDown();
        sc.StopSmallLaser();
    }
}
