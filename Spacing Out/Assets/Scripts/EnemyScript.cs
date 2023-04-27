using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{

    [SerializeField]
    private float Speed = 1f;

    [SerializeField]
    protected Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    private Vector2 Min, Max;

    [SerializeField]
    private float GetPlayerPositionDelay = 1f;

    protected static PlayerController Player;

    protected float LastSetPos;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void MoveShip()
    {
        float newX = transform.position.x + (Velocity.x * Speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * Speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "PlayerBullet")   
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    protected virtual void SetPosition()
    {
        Vector2 playerPos = GetPlayerPos();
        Vector2 newPos = new Vector2((playerPos.x - transform.position.x),-1f);
        Velocity = newPos;
        LastSetPos = Time.time;
    }

    public static void SetPlayer()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player");
        Player = player1.GetComponent<PlayerController>();
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
    
    protected bool IsReadyForSetPos()
    {
        return Time.time >= (LastSetPos + GetPlayerPositionDelay);
    }

}
