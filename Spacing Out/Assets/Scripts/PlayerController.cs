using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField]
    private float FireRate = 0.3f;

    private float lastShot;

    [SerializeField]
    private int speed = 1;

    [SerializeField]
    private float invincibleTime = 3;

    public GameController gameController;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    private Vector2 Min, Max;

    [SerializeField]
    private PlayerLaserAbility laser;

    [SerializeField]
    private StrongWeaponController strongWeapon;

    // [SerializeField]
    // private WeaponScript Abilities;

    [SerializeField]
    private float healthPoints = 1f;

    // [SerializeField]
    // private List<WeaponScript> Ablilties;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInvincibility();
        MoveShip();
    }

    private void HandleMovement()
    {
        Velocity = HandleHorizontal(Input.GetAxis("Horizontal"));
        Velocity += HandleVertical(Input.GetAxis("Vertical"));
    }

    private void HandleInvincibility()
    {
        bool isInvincible = (invincibleTime > 0) && (Mathf.Sin(Time.time * 20) > 0);
        GetComponent<Renderer>().enabled = !isInvincible;
        invincibleTime-=Time.deltaTime;
    }

    private Vector2 HandleHorizontal(float h)
    {
        return new Vector2(Mathf.Clamp(h,-1,1), 0);
    }

    private Vector2 HandleVertical(float v)
    {
        return new Vector2(0, Mathf.Clamp(v,-1,1));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "EnemyBullet" && invincibleTime <= 0)   
        {
            BulletScript bullet = other.GetComponent<BulletScript>();
            HandleDamage(bullet.Damage);
            bullet.HandleDamage(1);
        }
        else if(other.gameObject.tag == "EnemyLaser")
        {
            LaserScript laser = other.GetComponent<LaserScript>();
            HandleDamage(laser.Damage);
        }
        else if((other.gameObject.tag == "BigMeteorite" || other.gameObject.tag == "SmallMeteorite") && invincibleTime <= 0)
        {
            MeteorScript mt = other.GetComponent<MeteorScript>();
            HandleDamage(mt.Damage);
        }
        else if(other.gameObject.tag != "PlayerBullet" && other.gameObject.tag != "PlayerLaser" && invincibleTime <= 0)
        {
            HandleDamage(1);
        }

    }
    private void MoveShip()
    {
        float newX = transform.position.x + (Velocity.x * speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }

    private bool IsReadyForFire()
    {
        return Time.time >= (lastShot + FireRate);
    }

    // public float GetPositionX()
    // {
    //     return transform.position.x;
    // }

    public void HandleDamage(float Damage)
    {
        healthPoints -= Damage;
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if(healthPoints<=0)
        {
            laser.ShootDown();
            gameController.DestroyShuttle(this);
        }
    }


}
