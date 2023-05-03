using UnityEngine;

public class StrongWeaponController : WeaponScript
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
            base.HandleFire();
        }
    }
}
