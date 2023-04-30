using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathWeaponController : WeaponScript, IDamageble
{

    [SerializeField]
    private float HealthPoints = 100f;

    //[SerializeField]
    private float AttackTime, StartAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        LastShot = Time.time;
        StartAttackTime = Time.time - AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerBullet")
        {   
            BulletScript bullet = other.GetComponent<BulletScript>();
            HandleDamage(bullet.Damage);
            Destroy(bullet.gameObject);
        }
    }

    public void HandleDamage(float Damage)
    {
        HealthPoints -= Damage;
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if(HealthPoints<=0)
        {
            Destroy(this.gameObject);
        }
    }
    protected override bool IsReadyForFire()
    {
        return (Time.time >= (LastShot + FireRate)) && (Time.time < (StartAttackTime + AttackTime));
    }

    public void StartAttack(float attackTime)
    {
        StartAttackTime = Time.time; 
        AttackTime = attackTime;
    }

    public float GetHealth()
    {
        return HealthPoints;
    }
}
