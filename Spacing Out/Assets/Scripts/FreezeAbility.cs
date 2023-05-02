using UnityEngine;

public class FreezeAbility : MonoBehaviour
{

    [SerializeField]
    private float freezeTime = 3f;

    private bool freeze = false;

    [SerializeField]
    private float expandTime = 1.0f, reduceTime = 0.2f;

    [SerializeField]
    private float maxSize = 5.0f;

    [SerializeField]
    private GameObject field;

    private Vector3 originalScale;

    private float expandSpeed, reduceSpeed, curExpandTime = -1f;

    private bool isExpanding;

    void Start()
    {
        originalScale = field.transform.localScale;
        expandSpeed = maxSize / expandTime;  
        reduceSpeed = maxSize / reduceTime;
        Debug.Log(field);
    }

    private void Update()
    {
        if (freeze)
        {
            FreezeObjects();
            freeze = false;
        }
        if(curExpandTime > 0)
        {
            if(field.transform.localScale.x < maxSize)
                Expand();
            curExpandTime-=Time.deltaTime;
        }
        else
        {
            if(isExpanding)
            {
                Reduce();
                if(field.transform.localScale.x <= 0 && field.transform.localScale.y <= 0)
                {
                    field.transform.localScale = new Vector3(0,0,0);
                    isExpanding = false;
                }
            }
        }
    }

    private void FreezeObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            IFreezable freezable = obj.GetComponent<IFreezable>();
            if (obj.CompareTag("PlayerBullet") || obj.CompareTag("Player") || obj.CompareTag("PlayerWeapon"))
            {
                continue;
            }
            if(freezable != null )
            {
                freezable.Freeze(freezeTime);
            }
        }
        curExpandTime = freezeTime;
        isExpanding = true;
    }

    private void Expand()
    {
        field.transform.localScale += new Vector3(expandSpeed * Time.deltaTime, expandSpeed * Time.deltaTime, expandSpeed * Time.deltaTime);
    }

    private void Reduce()
    {
        field.transform.localScale -= new Vector3(reduceSpeed * Time.deltaTime, reduceSpeed * Time.deltaTime, reduceSpeed * Time.deltaTime);
    }
    
    public void StopTime()
    {
        freeze = true;
    }
}