using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponScript
{

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate) && transform.position.y<5;
    }
}
