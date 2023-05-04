using UnityEngine;

public class PlayerWeaponScript : WeaponScript
{
    private SoundController soundController;

    void Start() {
        soundController = FindObjectOfType<SoundController>();
    }

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
            soundController.PlayerShotSound();
            base.HandleFire();
        }
    }
}
