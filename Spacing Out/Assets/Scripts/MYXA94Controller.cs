using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYXA94Controller : EnemyScript
{

    [SerializeField]
    private WeaponScript FrontWeapon, LeftWeapon, RightWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SetPositionProtected();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForSetPos())
        {
            SetPositionProtected();
        }
        MoveShipProtected(); 
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
            newY = Random.Range(-1f,0.9f);
        }
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        LastSetPos = Time.time;
    }

}
