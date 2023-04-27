using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS16Controller : EnemyScript
{

    [SerializeField]
    private float FireRate = 0.6f;

    [SerializeField]
    private GameObject Bullet;

    private float LastShot;

    [SerializeField]
    private Transform FrontWeapon;

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
        Vector2 newPos = new Vector2((playerPos.x - transform.position.x) + Random.Range(-1f,1f), Random.Range(-1f,1f));
        Velocity = newPos;
        LastSetPos = Time.time;
    }

    protected void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = FrontWeapon.position;
    }

    protected bool IsReadyForFire()
    {
        return Time.time >= (LastShot + FireRate + Random.Range(-0.1f, 0.1f));
    }
}
