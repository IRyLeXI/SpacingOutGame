using UnityEngine;

public class GoliathWeaponController : WeaponScript, IDamageble
{

    [SerializeField]
    private float healthPoints = 100f;

    //[SerializeField]
    private float attackTime, startAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
        startAttackTime = Time.time - attackTime;
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

    public float GetHealth()
    {
        return healthPoints;
    }
}
