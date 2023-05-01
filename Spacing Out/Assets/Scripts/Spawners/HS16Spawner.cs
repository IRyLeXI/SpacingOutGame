using UnityEngine;

public class HS16Spawner : SpawnerScript, IEnemyShuttleSpawner
{
    [SerializeField]
    private HS16Controller Template;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReadyForSpawnWithAmount())
        {
            SpawnPrivate();
        }
        if(Amount<=0 && !isInfinite)
        {
            DestroyObject();
        }
    }

    public void Spawn()
    {
        SpawnPrivate();
    }

    private void SpawnPrivate()
    {
        HS16Controller mx = Instantiate(Template);
        Vector2 SpawnPoint = new Vector2(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), minSpawnPoint.position.y);
        mx.transform.position = SpawnPoint;
        lastSpawn = Time.time;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Amount -= 1;
    }
}
