using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGoliathController : BossScript
{

    //[SerializeField]
    //private List<W>
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
        float newX = Mathf.Clamp(Random.Range(-3f,3f),-1f,1f);
        float newY = 0;
        if(transform.position.y>2.6f)
        {
            newY = Mathf.Clamp((2.5f - transform.position.y),-1f, -0.5f);
            newX=0;
        }
        if((transform.position.x==Min.x && newX<0) || (transform.position.x==Max.x && newX>0))
        {
            newX = -newX;
        }
        Velocity.x = newX;
        Velocity.y = newY;
        LastSetPos = Time.time;
    }
}
