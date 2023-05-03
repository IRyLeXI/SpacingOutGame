using UnityEngine;

public class PlayerWeaponScript : WeaponScript
{

    void Update()
    {
        //Debug.Log($"ls {lastShot} time {Time.time}");
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override void HandleFire()
    {
        if(Input.GetButton("Fire"))
        {
            base.HandleFire();
        }
    }
}
