using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathWeaponController : MonoBehaviour, IDamageble
{

    [SerializeField]
    private float HealthPoints = 100f;

    [SerializeField]
    private float FireRate = 0.5f;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private float BulletPushForce = 12f;

    [SerializeField]
    private Vector2 BulletDirection;

    [SerializeField]
    private float AttackTime = 3f;

    private float LastShot, StartAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        LastShot = Time.time;
        StartAttackTime = Time.time - AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(StartAttackTime);
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

    private void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.pushForce = BulletPushForce;
        bulletScript.pushDirection = BulletDirection;
        bullet.transform.position = gameObject.transform.position;
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
    private bool IsReadyForFire()
    {
        return (Time.time >= (LastShot + FireRate)) && (Time.time < (StartAttackTime + AttackTime));
    }

    public void StartAttack()
    {
        StartAttackTime = Time.time; 
    }

}
