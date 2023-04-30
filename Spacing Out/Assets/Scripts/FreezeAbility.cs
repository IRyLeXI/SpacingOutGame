using UnityEngine;

public class FreezeAbility : MonoBehaviour
{
    public bool freeze = false;

    private void Update()
    {
        if (freeze)
        {
            FreezeObjects();
        }
    }

    private void FreezeObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("PlayerBullet") || obj.CompareTag("Player"))
            {
                continue;
            }
            Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}