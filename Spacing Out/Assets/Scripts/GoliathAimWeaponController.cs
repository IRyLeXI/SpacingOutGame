using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathAimWeaponController : WeaponScript
{
    [SerializeField]
    private float AttackTime = 3f;

    private float StartAttackTime;

    private static PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        LastShot = Time.time;
        StartAttackTime = Time.time - AttackTime;
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(StartAttackTime);
        if(IsReadyForFire())
        {
            HandleFire();
        }
    }

    protected override void HandleFire()
    {
        LastShot = Time.time;
        GameObject bullet = Instantiate(Bullet.gameObject);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        Vector2 playerPos = GetPlayerPos();
        //Mathf.Clamp(playerPos.x,-1f,1f);
        playerPos.x = playerPos.x - transform.position.x;
        playerPos.Normalize();
        playerPos.y = -1f;
        //playerPos.y = playerPos.y > 0 ? 1f : -1f;
        bulletScript.pushForce = BulletPushForce;
        bulletScript.pushDirection = playerPos;
        bullet.transform.position = gameObject.transform.position;
    }

    protected Vector2 GetPlayerPos()
    {
        Vector2 pos;
        if (Player!=null)
        {
            pos = Player.transform.position;
        }
        else
        {
            pos = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        }
        return pos;
    }

    public static void SetPlayer()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player");
        Player = player1.GetComponent<PlayerController>();
    }

    public void StartAttack()
    {
        StartAttackTime = Time.time; 
    }

    private bool IsReadyForFire()
    {
        return (Time.time >= (LastShot + FireRate)) && (Time.time < (StartAttackTime + AttackTime));
    }

}
