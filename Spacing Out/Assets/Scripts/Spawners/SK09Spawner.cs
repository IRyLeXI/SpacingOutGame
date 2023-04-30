using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK09Spawner : SpawnerScript, IEnemyShuttleSpawner
{
    [SerializeField]
    private SK09Controller Template;

    // Start is called before the first frame update
    void Start()
    {
        LastSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReadyForSpawnWithAmount())
        {
            SpawnPrivate();
        }
        if(Amount<=0)
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
        SK09Controller mx = Instantiate(Template);
        Vector2 SpawnPoint = new Vector2(Random.Range(MinSpawnPoint.position.x, MaxSpawnPoint.position.x), Random.Range(MinSpawnPoint.position.y, MaxSpawnPoint.position.y));
        // if(SpawnPoint.y<5.3)
        // {
        //     SpawnPoint.x = MaxSpawnPoint.position.x - SpawnPoint.x < SpawnPoint.x - MinSpawnPoint.position.x ? -6f : 6f;
        // }
        mx.transform.position = SpawnPoint;
        LastSpawn = Time.time;
        SpawnTime = SpawnRate + Random.Range(MinSpawnRate, MaxSpawnRate);
        Amount -= 1;
    }
}
