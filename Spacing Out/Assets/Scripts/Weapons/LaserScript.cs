using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float DistanceRay = 100f;

    [SerializeField]
    private Vector2 ColliderOffsetShooting, ColliderSizeShooting;

    [SerializeField]
    private float GrowthTime = 1f, FinalWidth = 2f;

    [SerializeField]
    private float AttackTime = 2f;

    private float GrowthSpeed, GrowthColliderSpeed, GrowthOffsetSpeed;

    private Vector2 ColliderGrowth = new Vector2(0f,0f), ColliderOffsetGrowth = new Vector2(0f,0f);

    public LineRenderer LineRenderer;

    private Transform LaserTransform;

    private BoxCollider2D laserCollider;

    private bool isFiring, isRestored;

    void Start()
    {
        LaserTransform = GetComponent<Transform>();
        laserCollider = GetComponent<BoxCollider2D>();
        GrowthSpeed = FinalWidth / GrowthTime;
        GrowthColliderSpeed = ColliderSizeShooting.x / GrowthTime;
        GrowthOffsetSpeed = ColliderOffsetShooting.x / GrowthTime;
        //Debug.Log(GrowthSpeed);
    }

    void Update()
    {
        if(isFiring && AttackTime>0)
        {
            if(LineRenderer.startWidth<FinalWidth)
            {
                GrowLaser();
            }
            else
            {
                HandleShoot();
            }
            AttackTime-=Time.deltaTime;
        }
        else 
        {
            if(!isRestored)
                RestoreDefault();
        }
    }

    private void HandleShoot()
    {
        Vector2 Pos = new Vector2(transform.position.x, -1f * DistanceRay);
        Draw2DRay(transform.position, Pos);
        laserCollider.size = ColliderSizeShooting;
        laserCollider.offset = new Vector2(0f, 2.5f);
    }

    private void RestoreDefault()
    {
        laserCollider.size = new Vector2(0f, 0f);
        laserCollider.offset =  new Vector2(0f, 0f);
        Draw2DRay(transform.position, transform.position);
        LineRenderer.startWidth = 0;
        isFiring = false;
        isRestored = true;
    }

    private void GrowLaser()
    {
        Draw2DRay(transform.position, transform.position);
        LineRenderer.startWidth += GrowthSpeed * Time.deltaTime;
        ColliderGrowth.x += GrowthColliderSpeed * Time.deltaTime;
        ColliderGrowth.y += GrowthColliderSpeed * Time.deltaTime;
        laserCollider.size = ColliderGrowth;
        ColliderOffsetGrowth.x += GrowthOffsetSpeed * Time.deltaTime;
        ColliderOffsetGrowth.y += GrowthOffsetSpeed * Time.deltaTime;
        laserCollider.offset = ColliderOffsetGrowth;
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        LineRenderer.SetPosition(0, startPos);
        LineRenderer.SetPosition(1, endPos);
    }

    public void StartAttack(float attackTime)
    {
        AttackTime = attackTime;
        isFiring = true;
        isRestored = false;
    }
}