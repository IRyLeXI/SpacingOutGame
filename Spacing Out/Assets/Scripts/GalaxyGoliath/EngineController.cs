using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour, IDamageble
{

    [SerializeField]
    private float HealthPoints = 100f;

    [SerializeField]
    private GalaxyGoliathController Goliath;

    private float StartHP;

    public bool Opened = false;

    private bool firstSlow = false, secondSlow = false, thirdSlow = false;

    private BoxCollider2D b_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
        b_Collider = GetComponent<BoxCollider2D>();
        b_Collider.enabled = false;
        StartHP = HealthPoints;
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
        if(HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
        else if(HealthPoints <= StartHP / 8 && !thirdSlow)
        {
            Goliath.SlowDown();
            thirdSlow = true;
        }
        else if(HealthPoints <= StartHP / 4 && !secondSlow)
        {
            Goliath.SlowDown();
            secondSlow = true;
        }
        else if(HealthPoints <= StartHP/2 && !firstSlow)
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
