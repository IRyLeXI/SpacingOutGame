using UnityEngine;

public class StrongWeaponController : WeaponScript
{
    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time - fireRate;
    }

    // Update is called once per frame
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
