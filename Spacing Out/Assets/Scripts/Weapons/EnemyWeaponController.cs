using UnityEngine;

public class EnemyWeaponController : WeaponScript
{

    private SoundController sc;

    void Start()
    {
        sc = FindObjectOfType<SoundController>();
    }

    void Update()
    {
        if(IsReadyForFire())
        {
            sc.EnemyShotSound();
            HandleFire();
        }
    }

    protected override bool IsReadyForFire()
    {
        return Time.time >= (lastShot + fireRate) && transform.position.y<5;
    }
}
