using UnityEngine;

public class ShieldController : MonoBehaviour, IDamageble
{
    [SerializeField]
    private int shieldDurability = 0;

    //[SerializeField]
    private SpriteRenderer shieldSprite;

    private bool isActive => shieldDurability > 0;

    private Collider2D cd;

    void Start()
    {
        cd = GetComponent<Collider2D>();
        shieldSprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!isActive)
        {
            shieldSprite.enabled = false;
            shieldDurability = -1;
        }
        else
        {
            shieldSprite.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(shieldDurability > 0)
        {
            if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("PlayerBullet") && !other.gameObject.CompareTag("PlayerLaser") && !other.gameObject.CompareTag("Buff"))
            {
                HandleDamage(1);
                if(other.gameObject.CompareTag("BigMeteorite") || other.gameObject.CompareTag("SmallMeteorite"))
                {
                    Destroy(other.gameObject);
                }  
            }
        }
    }

    public void HandleDamage(float Damage)
    {
        shieldDurability-=(int)Damage;
        if(shieldDurability<=0)
        {
            cd.enabled = false;
        }
    }

    public void IncreaseDurability()
    {
        if(!cd.enabled)
        {
            cd.enabled = true;
        }
        shieldDurability += shieldDurability == -1 ? 2 : 1;
        shieldDurability = Mathf.Clamp(shieldDurability, -1, 5);
    }

    public int GetDurability()
    {
        return shieldDurability;
    }

    private bool IsActive()
    {
        return shieldDurability>0;
    }
}
