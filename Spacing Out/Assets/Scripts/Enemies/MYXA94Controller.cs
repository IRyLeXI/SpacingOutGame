using UnityEngine;

public class MYXA94Controller : EnemyScript, IFreezable
{

    [SerializeField]
    private WeaponScript frontWeapon, leftWeapon, rightWeapon;

    
    private float freezeTime = -1f;

    // Start is called before the first frame update
    void Start()
    {
        SetPositionProtected();
    }

    // Update is called once per frame
    void Update()
    {
        if(freezeTime<0)
        {
            if(IsReadyForSetPos())
            {
                SetPositionProtected();
            }
            MoveShipProtected(); 
        }
        else
        {
            freezeTime -= Time.deltaTime;
        }
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
            newY = Random.Range(-1f,0.9f);
        }
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        lastSetPos = Time.time;
    }

    public void Freeze(float freezeTime)
    {
        this.freezeTime = freezeTime;
    }

}
