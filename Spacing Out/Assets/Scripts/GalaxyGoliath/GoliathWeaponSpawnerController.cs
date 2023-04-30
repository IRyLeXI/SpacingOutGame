using UnityEngine;

public class GoliathWeaponSpawnerController : WeaponScript
{

    [SerializeField]
    private int Amount;

    private float attackTime;

    private Vector2 spawnPoint1;

    protected override void HandleFire()
    {
        SpawnerScript spawner = Bullet.GetComponent<SpawnerScript>();
        var Obj = Instantiate(spawner);
        Obj.SetPosition(spawnPoint1, spawnPoint1);
        Obj.SetSpawnRate(Amount, attackTime);
    }

    public void StartAttack(float attackTime)
    {
        this.attackTime = attackTime;
        spawnPoint1 = new Vector2(this.transform.position.x, this.transform.position.y);
        HandleFire();   
    }
}
