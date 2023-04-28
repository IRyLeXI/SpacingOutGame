using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK09Controller : EnemyScript
{

    [SerializeField]
    private float rotateSpeed;

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
        Rotate();
    }

    protected override void SetPositionProtected()
    {
        Vector2 playerPos = GetPlayerPos();
        float newX = (playerPos.x - transform.position.x) + Random.Range(MinFaultX, MaxFaultX);
        float newY = (playerPos.y - transform.position.y) + Random.Range(-0.7f, -0.2f);
        Vector2 newPos = new Vector2(newX, newY);
        Velocity = newPos;
        LastSetPos = Time.time;
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

}
