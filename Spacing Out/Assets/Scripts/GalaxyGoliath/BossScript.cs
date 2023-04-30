using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour, IEnemyShuttle
{

    [SerializeField]
    protected float Speed = 1f;

    [SerializeField]
    protected float AttackDelay = 5f;

    [SerializeField]
    private float MovementDelay = 1f;

    // [SerializeField]
    // private float MinX, MaxX;

    [SerializeField]
    protected Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    protected Vector2 Min, Max;

    protected float LastSetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void MoveShipProtected()
    {
        float newX = transform.position.x + (Velocity.x * Speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * Speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }


    protected virtual void SetPositionProtected()
    {
        float newX = Random.Range(-1f,1f);
        float newY = Random.Range(-1f, 1f); 
        Velocity.x = newX;
        Velocity.y = newY;
        LastSetPos = Time.time;
    }

    protected bool IsReadyForSetPos()
    {
        return Time.time >= (LastSetPos + MovementDelay);
    }

    public void MoveShip()
    {
        MoveShipProtected();
    }

    public void SetPosition()
    {
        SetPositionProtected();
    }
}
