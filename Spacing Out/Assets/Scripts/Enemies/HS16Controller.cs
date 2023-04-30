using UnityEngine;

public class HS16Controller : EnemyScript
{
    
    [SerializeField]
    private WeaponScript frontWeapon;

    private float lastShot;


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
    }

    protected override void SetPositionProtected()
    {
        Vector2 playerPos = GetPlayerPos();
        float newX = Mathf.Clamp((playerPos.x - transform.position.x),-1,1) + Random.Range(minFaultX, maxFaultX);
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
        lastSetPos = Time.time;
    }
}
