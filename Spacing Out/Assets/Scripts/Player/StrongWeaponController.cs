using UnityEngine;

public class StrongWeaponController : WeaponScript
{
    private SoundController sc;

    void Start()
    {
        lastShot = Time.time - fireRate;
        sc = FindObjectOfType<SoundController>();
    }

    void Update()
    {
        if(IsReadyForFire())
        {
            sc.PlayerShotSound();
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
