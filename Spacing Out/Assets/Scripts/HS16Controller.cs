using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS16Controller : EnemyScript
{

    [SerializeField]
    private float FireRate = 0.6f;

    [SerializeField]
    private BulletScript Bullet;

    private float LastShot;

    [SerializeField]
    private Transform FrontWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SetPositionProtected();
        //LastShot = Time.time*3;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForSetPos())
        {
            SetPositionProtected();
        }
        MoveShipProtected(); 
        if(IsReadyForFire() && transform.position.y<5)
        {
            HandleFire();
        }
    }

    protected override void SetPositionProtected()
    {
        Vector2 playerPos = GetPlayerPos();
        float newX = Mathf.Clamp((playerPos.x - transform.position.x),-1,1) + Random.Range(MinFaultX, MaxFaultX);
        float newY;
        if(transform.position.y>5)
        {
            newY = -1;
            newX = 0;
        }
        else
        {
            newY = Random.Range(-1f,1f);
        }
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        LastSetPos = Time.time;
    }

    protected void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        bullet.transform.position = FrontWeapon.position;
    }

    protected bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate + Random.Range(-0.1f, 0.1f));
    }
}
