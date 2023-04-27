using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYXA94 : EnemyScript
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
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override void SetPosition()
    {
        Vector2 playerPos = GetPlayerPos();
        Vector2 newPos = new Vector2((playerPos.x - transform.position.x) + Random.Range(-1f,1f), Random.Range(-0.7f,1f));
        Velocity = newPos;
        LastSetPos = Time.time;
    }

    protected void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet1 = Instantiate(Bullet);
        bullet1.transform.position = FrontWeapon.position;
        GameObject bullet2 = Instantiate(Bullet);
        BulletScript bullet22 = bullet2.GetComponent<BulletScript>();
        bullet22.ChangeDirection(fireDirectionX);
        bullet2.transform.position = RightWeapon.position;
        GameObject bullet3 = Instantiate(Bullet);
        BulletScript bullet33 = bullet3.GetComponent<BulletScript>();
        bullet33.ChangeDirection(-fireDirectionX);
        bullet3.transform.position = LeftWeapon.position;
    }

    protected bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate + Random.Range(-0.1f, 0.1f));
    }
}
