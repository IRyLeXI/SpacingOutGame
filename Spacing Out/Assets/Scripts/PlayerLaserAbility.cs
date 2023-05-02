using UnityEngine;

public class PlayerLaserAbility : WeaponScript
{

    [SerializeField]
    private float attackTime = 1.5f;

    private LaserScript laser;

    //private bool isActive = false;

    void Start()
    {
        lastShot = Time.time - fireRate;
        GameObject bullet = Instantiate(Bullet);
        laser = bullet.GetComponent<LaserScript>();
    }

    void Update()
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
            laser.StartAttack(attackTime);
            lastShot = Time.time;
        }
    }

    public void ShootDown()
    {
        laser.ShutDown();
    }
}
