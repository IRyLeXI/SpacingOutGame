using UnityEngine;

public class LaserScript : MonoBehaviour, IFreezable
{
    [SerializeField]
    public float Damage = 20f;

    [SerializeField]
    private float distanceRay = 100f;

    [SerializeField]
    private Vector2 colliderOffsetShooting, colliderSizeShooting;

    [SerializeField]
    private float growthTime = 1f, finalWidth = 2f;

    [SerializeField]
    private float attackTime = 2f;

    private float growthSpeed, growthColliderSpeed, growthOffsetSpeed, attackTimeBackup;

    private Vector2 colliderGrowth = new Vector2(0f,0f), colliderOffsetGrowth = new Vector2(0f,0f);

    public LineRenderer lineRenderer;

    private Transform laserTransform;

    private BoxCollider2D laserCollider;

    public bool isFiring, isRestored;

    void Start()
    {
        laserTransform = GetComponent<Transform>();
        laserCollider = GetComponent<BoxCollider2D>();

        growthSpeed = finalWidth / growthTime;
        growthColliderSpeed = colliderSizeShooting.x / growthTime;
        growthOffsetSpeed = colliderOffsetShooting.x / growthTime;
        
        attackTimeBackup = attackTime;
    }

    void Update()
    {
        if(isFiring && attackTime > 0)
        {
            if(lineRenderer.startWidth<finalWidth)
            {
                GrowLaser();
            }
            else
            {
                HandleShoot();
            }
            attackTime-=Time.deltaTime;
        }
        else 
        {
            if(!isRestored)
                RestoreDefault();
        }
    }

    private void HandleShoot()
    {
        Vector2 Pos = new Vector2(transform.position.x, -1f * distanceRay);
        Draw2DRay(transform.position, Pos);
        laserCollider.size = colliderSizeShooting;
        laserCollider.offset = colliderOffsetShooting;
    }

    private void RestoreDefault()
    {
        if(gameObject!=null)
        {
            laserCollider.size = new Vector2(0.001f, 0.001f);
            laserCollider.offset = new Vector2(0.001f, 0.001f);

            Draw2DRay(transform.position, transform.position);
            colliderGrowth = new Vector2(0f, 0f);
            colliderOffsetGrowth = new Vector2(0f, 0f);

            attackTime = attackTimeBackup;
            lineRenderer.startWidth = 0;
            isFiring = false;
            isRestored = true;
        }
    }

    private void GrowLaser()
    {
        Draw2DRay(transform.position, transform.position);
        lineRenderer.startWidth += growthSpeed * Time.deltaTime;

        colliderGrowth.x += growthColliderSpeed * Time.deltaTime;
        colliderGrowth.y += growthColliderSpeed * Time.deltaTime;
        laserCollider.size = colliderGrowth;

        colliderOffsetGrowth.x += growthOffsetSpeed * Time.deltaTime;
        colliderOffsetGrowth.y += growthOffsetSpeed * Time.deltaTime;
        laserCollider.offset = colliderOffsetGrowth;
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    public void StartAttack(float attackTime)
    {
        this.attackTime = attackTime;
        attackTimeBackup = attackTime;
        isFiring = true;
        isRestored = false;
    }

    public void ShutDown()
    {
        RestoreDefault();
    }

    public void Freeze(float freezeTime)
    {
        attackTime+=freezeTime;
    }
}