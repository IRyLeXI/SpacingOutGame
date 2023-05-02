using UnityEngine;

public class BGController : MonoBehaviour, IFreezable
{
    private float freezeTime = -1f;
    void Update()
    {
        if(freezeTime<0)
        {
        transform.position += new Vector3(0, -1f * Time.deltaTime);

        if(transform.position.y<-10.83f)
        {
            transform.position = new Vector3(transform.position.x, 10.83f);
        }
        }
        else
        {
            freezeTime-=Time.deltaTime;
        }
    }

    public void Freeze(float freezeTime)
    {
        this.freezeTime = freezeTime;
    }
}
