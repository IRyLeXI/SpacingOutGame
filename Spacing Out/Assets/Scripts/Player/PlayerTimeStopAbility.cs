using UnityEngine;

public class PlayerTimeStopAbility : WeaponScript
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
