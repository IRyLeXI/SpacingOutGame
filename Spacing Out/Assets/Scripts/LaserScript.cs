using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    [SerializeField]
    private float DistanceRay = 100f; 

    public Transform laserFirePoint;

    public LineRenderer LineRenderer;

    private Transform LaserTransform;
    // Start is called before the first frame update
    void Start()
    {
        LaserTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Physics2D.Raycast(LaserTransform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * DistanceRay);
        }
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        LineRenderer.SetPosition(0, startPos);
        LineRenderer.SetPosition(1, endPos);
    }

}
