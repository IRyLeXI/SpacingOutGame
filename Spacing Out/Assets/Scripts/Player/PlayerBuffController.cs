using UnityEngine;

public class PlayerBuffController : MonoBehaviour
{

    [SerializeField]
    private float existingTime = 10f;

    [SerializeField]
    private float flickeringTime = 3f;

    [SerializeField]
    private float pushForce = 1f;

    [SerializeField]
    private Vector2 pushDirection = Vector2.down;

    private bool isActive => existingTime > 0;

    private bool isFlickering => existingTime < flickeringTime;

    private bool isVisible => !isFlickering || Mathf.Sin(Time.time * 30) > 0;

    private SpriteRenderer sprite;

    private Rigidbody2D rb;
   
    protected virtual void Start()
    {
        Push();
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        existingTime -= Time.deltaTime;
        sprite.enabled = isVisible;
        if(!isActive)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void Push()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }
}
