using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // [SerializeField]
    // private Vector2 Speed;

    [SerializeField]
    public float Damage = 1f;

    [SerializeField]
    public float pushForce;

    [SerializeField]
    public Vector2 pushDirection = Vector2.up;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        PushBullet();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    private void PushBullet()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }
    
    // private void MoveBullet()
    // {
    //     float newX = transform.position.x + (Speed.x * Time.deltaTime);
    //     float newY = transform.position.y + (Speed.y * Time.deltaTime);
    //     transform.position = new Vector2(newX, newY); 
    // }

    // private void DestroyBullet()
    // {
    //     Destroy(this.gameObject);
    // }

    public void ChangeDirection(float newDirection)
    {
        pushDirection.x = newDirection;
    }

}
