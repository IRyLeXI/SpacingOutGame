using UnityEngine;

public abstract class EnemyScript : MonoBehaviour, IDamageble
{

    [SerializeField]
    protected float Speed = 1f;

    [SerializeField]
    private float healthPoints = 1f;

    [SerializeField]
    protected Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    private Vector2 Min, Max;

    [SerializeField]
    protected float minFaultX = 1f, maxFaultX = 1f;

    [SerializeField]
    private float getPlayerPositionDelay = 1f;

    [SerializeField]
    protected int scoreValue = 10;

    protected static PlayerController Player;

    protected GameController gameController;

    protected float lastSetPos;

    protected void MoveShipProtected()
    {
        float newX = transform.position.x + (Velocity.x * Speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * Speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "PlayerBullet" && transform.position.y  <5.7)   
        {
            BulletScript bullet = other.GetComponent<BulletScript>();
            HandleDamage(bullet.Damage);
            bullet.HandleDamage(1);
        }
        else if(other.gameObject.tag == "PlayerLaser" && transform.position.y < 6)
        {
            LaserScript laser = other.GetComponent<LaserScript>();
            HandleDamage(laser.Damage);
        }

    }

    public void SetPosition()
    {
        SetPositionProtected();
    }

    protected virtual void SetPositionProtected()
    {
        Vector2 playerPos = GetPlayerPos();
        Vector2 newPos = new Vector2((playerPos.x - transform.position.x),-1f);
        Velocity = newPos;
        lastSetPos = Time.time;
    }

    public static void SetPlayer(PlayerController player1)
    {
        Player = player1.GetComponent<PlayerController>();
    }

    protected Vector2 GetPlayerPos()
    {
        Vector2 pos;
        if (Player!=null)
        {
            pos = Player.transform.position;
        }
        else
        {
            pos = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        }
        return pos;
    }
    
    protected bool IsReadyForSetPos()
    {
        return Time.time >= (lastSetPos + getPlayerPositionDelay);
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
    public void MoveShip()
    {
        MoveShipProtected();
    }

    public void SetController(GameController controller)
    {
        gameController = controller;
    }
}
