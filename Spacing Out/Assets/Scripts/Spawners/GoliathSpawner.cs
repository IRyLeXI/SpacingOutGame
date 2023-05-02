using UnityEngine;

public class GoliathSpawner : SpawnerScript, IFreezable
{   
    [SerializeField]
    private GalaxyGoliathController Template;

    private float freezeTime = -1f;

    void Start()
    {
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
        GalaxyGoliathController mx = Instantiate(Template);
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
