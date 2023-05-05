using UnityEngine;

public class BulletScript : MonoBehaviour, IDamageble, IFreezable
{

    [SerializeField]
    public float Damage = 1f;

    [SerializeField]
    public float pushForce;
    
    [SerializeField]
    private float healthPoints = 1f;

    [SerializeField]
    public Vector2 pushDirection = Vector2.up;

    private Rigidbody2D rb;

    //private float freezeTime = -1f;
    
    //private bool isFreezed = false;

    private SoundController sc;

    void Start()
    {
        PushBullet();
        sc = FindObjectOfType<SoundController>();
    }

    void Update() {

    }   

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    protected void PushBullet()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        Rotate();
    }
    

    public void ChangeDirection(float newDirection)
    {
        pushDirection.x = newDirection;
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(pushDirection.y, pushDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
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
            sc.HitSound();
            Destroy(this.gameObject);
        }
    }

    public void Freeze(float freezeTime)
    {
        if(gameObject!=null)
        {
            //this.freezeTime = freezeTime;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            //isFreezed = true;
            Invoke(nameof(Unfreeze), freezeTime);
        }
    }

    private void Unfreeze()
    {
        PushBullet();
        //isFreezed = false;
    }

}
