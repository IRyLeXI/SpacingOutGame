using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    private void PushBullet()
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
}