using UnityEngine;

public class PlayerWeaponScript : WeaponScript
{


    // Start is called before the first frame update
    void Start()
    {
        
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
        if(Input.GetButton("Fire"))
        {
            base.HandleFire();
        }
    }
}
