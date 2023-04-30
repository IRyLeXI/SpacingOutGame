using UnityEngine;

public class BGController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1f * Time.deltaTime);

        if(transform.position.y<-10.83f)
        {
            transform.position = new Vector3(transform.position.x, 10.83f);
        }
    }
}
