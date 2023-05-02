using UnityEngine;

public class PlayerWeaponScript : WeaponScript
{

    void Start()
    {
        
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
        if(Input.GetButton("Fire"))
        {
            base.HandleFire();
        }
    }
}
