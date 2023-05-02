using UnityEngine;

public class SK09Controller : EnemyScript, IFreezable
{

    [SerializeField]
    private float rotateSpeed;
    
    private float freezeTime = -1f;

    void Start()
    {
        SetPositionProtected();
    }

    void Update()
    {
        if(freezeTime<0)
        {
            if(IsReadyForSetPos())
            {
                SetPositionProtected();
            }
            MoveShipProtected();     
            Rotate();
        }
        else
        {
            freezeTime -= Time.deltaTime;
        }
    }

    protected override void SetPositionProtected()
    {
        Vector2 playerPos = GetPlayerPos();
        float newX = Mathf.Clamp((playerPos.x - transform.position.x), -1, 1) + Random.Range(minFaultX, maxFaultX);
        float newY = Mathf.Clamp((playerPos.y - transform.position.y), -1, 1) + Random.Range(-0.7f, -0.2f);
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        lastSetPos = Time.time;
    }

    private void Rotate()
    {
        if (Player!=null)
        {
            Vector2 direction = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }

    public void Freeze(float freezeTime)
    {
        this.freezeTime = freezeTime;

    }
}
