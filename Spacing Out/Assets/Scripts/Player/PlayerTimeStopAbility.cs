using UnityEngine;

public class PlayerTimeStopAbility : WeaponScript
{
    void Start()
    {
        lastShot = Time.time - fireRate;
    }

    void Update()
    {
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override void HandleFire()
    {
        if(Input.GetButton("Special"))
        {
            FreezeAbility freezer = Bullet.GetComponent<FreezeAbility>();
            freezer.StopTime();
            lastShot = Time.time; 
        }
    }
}
