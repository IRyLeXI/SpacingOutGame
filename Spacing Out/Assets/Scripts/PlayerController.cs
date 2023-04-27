using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float FireRate = 0.3f;

    private float LastShot;

    [SerializeField]
    private int Speed = 1;

    [SerializeField]
    private float InvincibleTime = 3;

    public GameController GameController;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    private Vector2 Min, Max;

    [SerializeField]
    private Transform FrontWeapon;

    // Start is called before the first frame update
    void Start()
    {
        LastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        if(IsReadyForFire())
        {
            HandleFire();
        }
        HandleInvincibility();
        MoveShip();
    }

    private void HandleMovement()
    {
        Velocity = HandleHorizontal(Input.GetAxis("Horizontal"));
        Velocity += HandleVertical(Input.GetAxis("Vertical"));
    }

    private void HandleFire()
    {
        if(Input.GetButton("Fire"))
        {
            LastShot = Time.time;
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = FrontWeapon.position;
        }
    }

    private void HandleInvincibility()
    {
        bool isInvincible = (InvincibleTime > 0) && (Mathf.Sin(Time.time * 20) > 0);
        GetComponent<Renderer>().enabled = !isInvincible;
        InvincibleTime-=Time.deltaTime;
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
        if(other.gameObject.tag != "PlayerBullet" && InvincibleTime <= 0)   
        {
            GameController.DestroyShuttle(this);
            Destroy(other.gameObject);
        }
    }
    private void MoveShip()
    {
        float newX = transform.position.x + (Velocity.x * Speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * Speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }

    private bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate);
    }

    // public float GetPositionX()
    // {
    //     return transform.position.x;
    // }

    
}
