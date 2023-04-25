using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    public float RotationSpeed;
    
    public Vector2 Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateMeteor();
        MoveMeteor();
    }

    private void RotateMeteor()
    {
        float newZ = transform.rotation.eulerAngles.z + (RotationSpeed * Time.deltaTime);
        Vector3 newR = new (0, 0, newZ);
        transform.rotation = Quaternion.Euler(newR);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            DestroyMeteor(other);
        }
    }

    private void MoveMeteor()
    {
        float newX = transform.position.x + (Speed.x * Time.deltaTime);
        float newY = transform.position.y + (Speed.y * Time.deltaTime);
        transform.position = new Vector2(newX, newY); 
    }

    private void DestroyMeteor(Collider2D bullet)
    {
        Destroy(bullet.gameObject);
        Destroy(this.gameObject);
    }

}
