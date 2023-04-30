using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGoliathController : BossScript
{

    [SerializeField]
    private List<WeaponScript> WeaponsAttack1;

    [SerializeField]
    private List<WeaponScript> WeaponsAttack2;

   
    [SerializeField]
    protected float AttackTime = 3f;

    private float LastAttackTime;

    private float DistY;
    
    private delegate void Attack();

    private List<Attack> AttackList;

    private Attack LastAttack;

    private int CurrentAttack;

    // Start is called before the first frame update
    void Start()
    {
        DistY = 2.6f - transform.position.y;
        SetPositionProtected();
        LastAttackTime = Time.time - AttackTime;
        AttackList = new List<Attack>() {HandleAttack1, HandleAttack2};
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
            CurrentAttack = Random.Range(0, AttackList.Count);
            AttackList[CurrentAttack]();
            if(LastAttack!=null)
            {
                AttackList.Add(LastAttack);
            }
            LastAttack = AttackList[CurrentAttack];
            AttackList.RemoveAt(CurrentAttack);
            LastAttackTime = Time.time;
        }
        if(!IsAttacking())
        {
            MoveShipProtected(); 
        }
        if(WeaponsAttack1.Count == 0)
        {
            DestroyGoliath();
        }
        UpdateWeapons();
    }

    private void HandleAttack1()
    {
        Debug.Log(WeaponsAttack1.Count);
        foreach(GoliathWeaponController Weapon in WeaponsAttack1)
        {
            Weapon.StartAttack();
        }
    }

    private void HandleAttack2()
    {
        foreach(GoliathAimWeaponController Weapon in WeaponsAttack2)
        {
            Weapon.StartAttack();
        }
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

    private void UpdateWeapons()
    {
        for (int i = 0; i < WeaponsAttack1.Count; i++)
        {
            GoliathWeaponController weapon = (GoliathWeaponController)WeaponsAttack1[i];
            if (weapon == null)
            {
                WeaponsAttack1.RemoveAt(i);
                i--;
            }
        }
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
        return Time.time >= (LastAttackTime + AttackTime + AttackDelay);
    }

    private bool IsAttacking()
    {
        return Time.time < (LastAttackTime + AttackTime);
    }

    private void DestroyGoliath()
    {
        Destroy(this.gameObject);
    }
}
