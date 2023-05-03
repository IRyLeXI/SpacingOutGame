using UnityEngine;

public class TeleportBulletScript : BulletScript
{
    public Sprite[] frames;
    public float animationSpeed = 0.1f; 
    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float animationTimer = 0f;

    private Object[] framePrefabs;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        framePrefabs = new Object[frames.Length];
        for (int i = 0; i < frames.Length; i++)
        {
            framePrefabs[i] = Resources.Load(frames[i].name);
        }
        PushBullet();
    }

    void Update()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= animationSpeed)
        {
            animationTimer -= animationSpeed;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }

    private void OnDestroy()
    {
        foreach (Object prefab in framePrefabs)
        {
            Resources.UnloadAsset(prefab);
        }
        framePrefabs = null;
    }
}
