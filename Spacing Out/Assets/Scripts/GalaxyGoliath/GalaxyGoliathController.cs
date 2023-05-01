using System.Collections.Generic;
using UnityEngine;

public class GalaxyGoliathController : BossScript
{

    [SerializeField]
    private List<WeaponScript> weaponsAttack1;

    [SerializeField]
    private List<WeaponScript> weaponsAttack2;

    [SerializeField]
    private List<GoliathWeaponSpawnerController> weaponsAttack3;

    [SerializeField]
    private LaserScript weapon4;

    [SerializeField]
    private EngineController Engine;

    [SerializeField]
    protected float attackTime = 3f;

    private float lastAttackTime;

    private float distY;
    
    private delegate void Attack();

    private List<Attack> attackList;

    private Attack lastAttack;

    private int currentAttack;

    // Start is called before the first frame update
    void Start()
    {
        distY = 2.6f - transform.position.y;
        SetPositionProtected();
        lastAttackTime = Time.time - attackTime;
        attackList = new List<Attack>() {HandleAttack1, HandleAttack2, HandleAttack3, HandleAttack4};
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
            ExecuteAttack();
        }
        if(!IsAttacking())
        {
            MoveShipProtected(); 
        }
        if(Engine == null)
        {
            DestroyGoliath();
        }
        if(weaponsAttack1.Count == 0 && !Engine.IsOpened())
        {
            Engine.OpenUp();
            attackList.Remove(HandleAttack1);
            if(lastAttack == HandleAttack1) lastAttack = null;
        }
        UpdateWeapons();
    }

    private void HandleAttack1()
    {
        Debug.Log(weaponsAttack1.Count);
        foreach(GoliathWeaponController Weapon in weaponsAttack1)
        {
            Weapon.StartAttack(attackTime);
        }
    }

    private void ExecuteAttack()
    {
        currentAttack = Random.Range(0, attackList.Count);
        attackList[currentAttack]();
        if(lastAttack!=null)
        {
            attackList.Add(lastAttack);
        }
        lastAttack = attackList[currentAttack];
        if(attackList.Count!=1) 
            attackList.RemoveAt(currentAttack);
        lastAttackTime = Time.time;
    }


    private void HandleAttack2()
    {
        foreach(GoliathAimWeaponController Weapon in weaponsAttack2)
        {
            Weapon.StartAttack(attackTime);
        }
    }

    private void HandleAttack3()
    {
        foreach(GoliathWeaponSpawnerController Weapon in weaponsAttack3)
        {
            Weapon.StartAttack(attackTime);
        }
    }

    private void HandleAttack4()
    {
        weapon4.StartAttack(attackTime);
    }

    protected override void MoveShipProtected()
    {
        if(transform.position.y>2.7f)
        {
            Velocity.y = distY / 3f;
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
        for (int i = 0; i < weaponsAttack1.Count; i++)
        {
            GoliathWeaponController weapon = (GoliathWeaponController)weaponsAttack1[i];
            if (weapon == null)
            {
                weaponsAttack1.RemoveAt(i);
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
        lastSetPos = Time.time;
    }

    private bool IsReadyForAttack()
    {
        return Time.time >= (lastAttackTime + attackTime + attackDelay);
    }

    private bool IsAttacking()
    {
        return Time.time < (lastAttackTime + attackTime);
    }
    
    private void DestroyGoliath()
    {
        weapon4.ShutDown();
        Destroy(this.gameObject);
    }
    

    public void SlowDown()
    {
        Speed/=2;
    }
}
