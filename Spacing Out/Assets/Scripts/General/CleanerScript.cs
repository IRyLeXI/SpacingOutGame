using UnityEngine;

public class CleanerScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(gameObject.transform.position.x) > 5.3f || Mathf.Abs(gameObject.transform.position.y) > 6.6)
        {
            Destroy(this.gameObject);
        }
    }
}
