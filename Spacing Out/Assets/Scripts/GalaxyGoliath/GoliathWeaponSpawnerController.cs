using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathWeaponSpawnerController : WeaponScript
{

    [SerializeField]
    private int Amount;

    private float AttackTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void HandleFire()
    {
        SpawnerScript spawner = Bullet.GetComponent<SpawnerScript>();
        var Obj = Instantiate(spawner);
        Obj.SetPosition(this.transform, this.transform);
        Obj.SetSpawnRate(Amount, AttackTime);
    }

    public void StartAttack(float attackTime)
    {
        AttackTime = attackTime;
        HandleFire();
    }
}
