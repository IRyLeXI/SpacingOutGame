using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{

    [SerializeField]
    private List<PlayerWeaponScript> Weapons;

    [SerializeField]
    private float weaponsDamage = 1f, weaponsShotSpeed = 0.2f;

    [SerializeField]
    private StrongWeaponController strongShotAbility;

    [SerializeField]
    private PlayerTeleportAbility teleportAbility;

    [SerializeField]
    public PlayerLaserAbility laserAbility;

    [SerializeField]
    private PlayerTimeStopAbility timeStopAbility;

    [SerializeField]
    public bool IsStrongWeapon = true, IsTeleportAbility = false, IsLaserAbility = false, IsTimeStopAbility = false;

    private float sideWeaponsHandleTime, weaponsBuffTime;

    private bool isDamageChanged = true, isShotSpeedChanged = true;

    //private DataSaverScript ds;

    void Start()
    {
        SetDamage(weaponsDamage);
        SetShotSpeed(weaponsShotSpeed);
        //ds.GetComponent<DataSaverScript>();
        SetAbility();
        if(!IsStrongWeapon)
            strongShotAbility.gameObject.SetActive(false);

        if(!IsTeleportAbility)
            teleportAbility.gameObject.SetActive(false);

        if(!IsLaserAbility)
            laserAbility.gameObject.SetActive(false);

        if(!IsTimeStopAbility)
            timeStopAbility.gameObject.SetActive(false);
    }

    void Update()
    {
        if(sideWeaponsHandleTime>0)
        {
            sideWeaponsHandleTime-=Time.deltaTime;
        }
        else
        {
            if(isShotSpeedChanged)
            {
                DeactivateSideWeapons();
                SetShotSpeed(weaponsShotSpeed);
                isShotSpeedChanged = false;
            }
        }
        if(weaponsBuffTime>0)
        {
            weaponsBuffTime-=Time.deltaTime;
        }
        else
        {
            if(isDamageChanged)
            {
                SetDamage(weaponsDamage);
                isDamageChanged = false;
            }
        }
    }

    public void ActivateSideWeapons(float newShotSpeed, float aTime)
    {
        Weapons[1].gameObject.SetActive(true);
        Weapons[2].gameObject.SetActive(true);
        SetShotSpeed(newShotSpeed);
        sideWeaponsHandleTime = aTime;
        isShotSpeedChanged = true;
    }

    private void DeactivateSideWeapons()
    {
        SetShotSpeed(weaponsShotSpeed);
        Weapons[1].gameObject.SetActive(false);
        Weapons[2].gameObject.SetActive(false);
    }

    public void BuffBullets(float damage, float aTime)
    {
        SetDamage(damage);
        weaponsBuffTime = aTime;
        isDamageChanged = true;
    }

    private void SetDamage(float damage)
    {
        foreach(PlayerWeaponScript weapon in Weapons)
        {
            weapon.SetNewDamage(damage);
        }
    }

    private void SetShotSpeed(float shotSpeed)
    {
        foreach (PlayerWeaponScript weapon in Weapons)
        {
            weapon.SetNewShotSpeed(shotSpeed);
        }
    }

    private void SetAbility()
    {
        if(DataSaverScript.AbilityNumber == 1)
        {
            IsStrongWeapon = true;
        }
        else if(DataSaverScript.AbilityNumber == 2)
        {
            IsLaserAbility = true;
        }
        else if(DataSaverScript.AbilityNumber == 3)
        {
            IsTeleportAbility = true;
        }
        else if(DataSaverScript.AbilityNumber == 4)
        {
            IsTimeStopAbility = true;
        }
    }

}
