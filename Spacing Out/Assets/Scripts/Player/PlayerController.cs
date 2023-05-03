using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField]
    private int speed = 1;

    [SerializeField]
    private float invincibleTime = 3;

    public GameController gameController;

    [SerializeField]
    private Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    private Vector2 Min, Max;

    [SerializeField]
    public PlayerWeaponsController weaponsController;

    [SerializeField]
    private float healthPoints = 1f;

    public ShieldController shield;

    private Collider2D cd;
    private bool isDeathTriggered = false;

    void Start() {
        cd = GetComponent<Collider2D>();
    }

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
        if(isDeathTriggered)
            return;
        if(invincibleTime <= 0)
        {
            if (other.CompareTag("EnemyBullet"))
            {
                BulletScript bullet = other.GetComponent<BulletScript>();
                if (shield.GetDurability() < 0)
                {
                    HandleDamage(bullet.Damage);
                }
                bullet.HandleDamage(1);
            }
            else if (other.CompareTag("EnemyLaser"))
            {
                LaserScript laser = other.GetComponent<LaserScript>();
                shield.HandleDamage(shield.GetDurability());
                HandleDamage(laser.Damage);

            }
            else if ((other.CompareTag("BigMeteorite") || other.CompareTag("SmallMeteorite")))
            {
                MeteorScript mt = other.GetComponent<MeteorScript>();
                Debug.Log(shield.GetDurability());
                if (shield.GetDurability() < 0)
                {
                    HandleDamage(mt.Damage);
                }
            }
            else if (!other.CompareTag("PlayerBullet") && !other.CompareTag("PlayerLaser") && !other.CompareTag("Buff"))
            {
                if (shield.GetDurability() < 0)
                {
                    HandleDamage(1);
                }
            }
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

    public void HandleDamage(float Damage)
    {
        healthPoints -= Damage;
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if(healthPoints<=0)
        {
            //Debug.Log(weaponsController.laserAbility.gameObject.activeSelf);
            if(weaponsController.laserAbility.gameObject.activeSelf) 
            {
                weaponsController.laserAbility.ShootDown();
            }
            isDeathTriggered = true;    
            gameController.DestroyShuttle(this);
        }
    }
}
