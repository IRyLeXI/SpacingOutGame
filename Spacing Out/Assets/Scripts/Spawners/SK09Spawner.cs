using UnityEngine;

public class SK09Spawner : SpawnerScript, IEnemyShuttleSpawner, IFreezable
{
    [SerializeField]
    private SK09Controller Template;

    private float freezeTime = -1f;
    
    protected override void Start()
    {
        base.Start();
        lastSpawn = Time.time - spawnRate;
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
        SK09Controller mx = Instantiate(Template);
        mx.SetController(gameController);
        Vector2 SpawnPoint = new Vector2(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), Random.Range(minSpawnPoint.position.y, maxSpawnPoint.position.y));
        mx.transform.position = SpawnPoint;
        lastSpawn = Time.time;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Amount -= 1;
    }

    public void Freeze(float freezeTime)
    {
        this.freezeTime = freezeTime;
        lastSpawn = Mathf.Max(Time.time + freezeTime, lastSpawn);
    }
}
