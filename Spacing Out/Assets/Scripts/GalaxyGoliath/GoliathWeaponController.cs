using UnityEngine;

public class GoliathWeaponController : WeaponScript, IDamageble
{

    [SerializeField]
    private float healthPoints = 100f;

    [SerializeField]
    private HealthBarController healthBar;

    private float attackTime, startAttackTime;

    private SoundController sc;


    void Start()
    {
        lastShot = Time.time;
        startAttackTime = Time.time - attackTime;
        sc = FindObjectOfType<SoundController>();
        healthBar.SetMaxHealth(healthPoints);
        healthBar.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
    }

    void Update()
    {
        if(IsReadyForFire())
        {
            sc.EnemyShotSound();
            HandleFire();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerBullet")
        {   
            BulletScript bullet = other.GetComponent<BulletScript>();
            HandleDamage(bullet.Damage);
            bullet.HandleDamage(1);
        }
        else if(other.gameObject.tag == "PlayerLaser")
        {
            LaserScript laser = other.GetComponent<LaserScript>();
            HandleDamage(laser.Damage);
        }
    }
    

    public void HandleDamage(float Damage)
    {
        healthPoints -= Damage;
        healthBar.SetHealth(Mathf.Max(healthPoints, 0));
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if(healthPoints<=0)
        {
            Destroy(this.gameObject);
        }
    }
    protected override bool IsReadyForFire()
    {
        return (Time.time >= (lastShot + fireRate)) && (Time.time < (startAttackTime + attackTime));
    }

    public void StartAttack(float attackTime)
    {
        startAttackTime = Time.time; 
        this.attackTime = attackTime;
    }

}
