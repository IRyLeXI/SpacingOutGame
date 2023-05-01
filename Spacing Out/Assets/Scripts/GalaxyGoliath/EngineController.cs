using UnityEngine;

public class EngineController : MonoBehaviour, IDamageble
{

    [SerializeField]
    private float healthPoints = 100f;

    [SerializeField]
    private GalaxyGoliathController Goliath;

    private float startHP;

    public bool Opened = false;

    private bool firstSlow = false, secondSlow = false, thirdSlow = false;

    private BoxCollider2D b_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
        b_Collider = GetComponent<BoxCollider2D>();
        b_Collider.enabled = false;
        startHP = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
        else if(healthPoints <= startHP / 8 && !thirdSlow)
        {
            Goliath.SlowDown();
            thirdSlow = true;
        }
        else if(healthPoints <= startHP / 4 && !secondSlow)
        {
            Goliath.SlowDown();
            secondSlow = true;
        }
        else if(healthPoints <= startHP/2 && !firstSlow)
        {
            Goliath.SlowDown();
            firstSlow = true;
        }
        
    }

    public void OpenUp()
    {
        Opened = true;
        b_Collider.enabled = true;
    }

    public bool IsOpened()
    {
        return Opened;
    }

}
