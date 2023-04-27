using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYXA94Controller : EnemyScript
{
     [SerializeField]
    private float FireRate = 1.4f;

    [SerializeField]
    private GameObject Bullet;

    private float LastShot;

    [SerializeField]
    private Transform FrontWeapon, LeftWeapon, RightWeapon;

    [SerializeField]
    private float fireDirectionX;

    // Start is called before the first frame update
    void Start()
    {
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForSetPos())
        {
            SetPosition();
        }
        MoveShip(); 
        if(IsReadyForFire() && transform.position.y<5)
        {
            HandleFire();
        }
    }

    protected override void SetPosition()
    {
        Vector2 playerPos = GetPlayerPos();
        float newX = (playerPos.x - transform.position.x) + Random.Range(MinFaultX, MaxFaultX);
        float newY;
        if(transform.position.y>5)
        {
            newY = -1;
        }
        else
        {
            newY = Random.Range(-1f,0.9f);
        }
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        LastSetPos = Time.time;
    }

    protected void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet1 = Instantiate(Bullet);
        bullet1.transform.position = FrontWeapon.position;
        GameObject bullet2 = Instantiate(Bullet);
        BulletScript bulletRight = bullet2.GetComponent<BulletScript>();
        bulletRight.ChangeDirection(fireDirectionX);
        bullet2.transform.position = RightWeapon.position;
        GameObject bullet3 = Instantiate(Bullet);
        BulletScript bulletLeft = bullet3.GetComponent<BulletScript>();
        bulletLeft.ChangeDirection(-fireDirectionX);
        bullet3.transform.position = LeftWeapon.position;
    }

    protected bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate + Random.Range(-0.1f, 0.1f));
    }
}
