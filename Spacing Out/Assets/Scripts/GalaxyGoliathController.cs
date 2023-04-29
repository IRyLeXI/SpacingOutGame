using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGoliathController : BossScript
{

    [SerializeField]
    private List<GoliathWeaponController> WeaponsAttack1;

    [SerializeField]
    private GoliathAimWeaponController WeaponAttack2;

    [SerializeField]
    protected float AttackTime = 3f;

    private float LastAttack;

    private float DistY;

    // Start is called before the first frame update
    void Start()
    {
        DistY = 2.6f - transform.position.y;
        SetPositionProtected();
        LastAttack = Time.time - AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForSetPos())
        {
            SetPositionProtected();
        }
        if(IsReadyForAttack())
        {
            HandleAttack2();
            LastAttack = Time.time;
        }
        if(!IsAttacking())
        {
            MoveShipProtected(); 
        }
    }

    private void HandleAttack1()
    {
        foreach(GoliathWeaponController Weapon in WeaponsAttack1)
        {
            Weapon.StartAttack();
        }
    }

    private void HandleAttack2()
    {
        WeaponAttack2.StartAttack();
    }

    protected override void MoveShipProtected()
    {
        if(transform.position.y>2.7f)
        {
            Velocity.y = DistY / 3f;
            Velocity.x=0;
        }
        if((transform.position.x==Min.x && Velocity.x<0) || (transform.position.x==Max.x && Velocity.x>0))
        {
            Velocity.x = -Velocity.x;
        }
        base.MoveShipProtected();
    }

    protected override void SetPositionProtected()
    {
        float newX = Mathf.Clamp(Random.Range(-3f,3f),-1f,1f);
        float newY = 0;
        Velocity.x = newX;
        Velocity.y = newY;
        LastSetPos = Time.time;
    }

    private bool IsReadyForAttack()
    {
        return Time.time >= (LastAttack + AttackTime + AttackDelay);
    }

    private bool IsAttacking()
    {
        return Time.time < (LastAttack + AttackTime);
    }
}
