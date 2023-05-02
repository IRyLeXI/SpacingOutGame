using UnityEngine;

public class MYXA94Spawner : SpawnerScript, IEnemyShuttleSpawner, IFreezable
{
    [SerializeField]
    private MYXA94Controller Template;
    
    private float freezeTime = -1f;
    
    void Start()
    {
        lastSpawn = Time.time;
    }

    void Update()
    {
        if(freezeTime<0)
        {
            if (IsReadyForSpawnWithAmount())
            {
                SpawnPrivate();
            }
            if (Amount <= 0 && !isInfinite)
            {
                DestroyObject();
            }
        }
        else
        {
            freezeTime-=Time.deltaTime;
        }
    }

    public void Spawn()
    {
        SpawnPrivate();
    }

    private void SpawnPrivate()
    {
        MYXA94Controller mx = Instantiate(Template);
        Vector2 SpawnPoint = new Vector2(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), minSpawnPoint.position.y);
        mx.transform.position = SpawnPoint;
        lastSpawn = Time.time;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Amount -= 1;
    }

    public void Freeze(float freezeTime)
    {
        this.freezeTime = freezeTime;
    }
}
