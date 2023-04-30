using UnityEngine;

public class EnemyWeaponController : WeaponScript
{
    void Update()
    {
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override bool IsReadyForFire()
    {
        return Time.time >= (lastShot + fireRate) && transform.position.y<5;
    }
}
