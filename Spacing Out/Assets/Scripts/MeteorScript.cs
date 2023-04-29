using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour, IDamageble
{
    
    [SerializeField]
    protected internal float RotationSpeed;

    [SerializeField]
    public float Damage = 10f;

    [SerializeField]
    private float HealthPoints = 1f;

    [SerializeField]
    protected internal float pushForce;

    [SerializeField]
    protected internal Vector2 pushDirection = Vector2.down;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        PushMeteorite();
    }

    // Update is called once per frame
    void Update()
    {
        RotateMeteor(); 
    }

    private void RotateMeteor()
    {
        float newZ = transform.rotation.eulerAngles.z + (RotationSpeed * Time.deltaTime);
        Vector3 newR = new (0, 0, newZ);
        transform.rotation = Quaternion.Euler(newR);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
    //Debug.Log("Meteor touched");
        if(other.gameObject.tag == "PlayerBullet")
        {
            BulletScript bullet = other.GetComponent<BulletScript>();
            HandleDamage(bullet.Damage);
            Destroy(bullet.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            HandleDamage(1);
        }
    }

    private void PushMeteorite()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }

    private void DestroyMeteor(Collider2D bullet)
    {
        Destroy(this.gameObject);
        Destroy(bullet.gameObject);
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

}
