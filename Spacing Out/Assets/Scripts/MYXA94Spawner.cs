using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYXA94Spawner : SpawnerScript, IEnemyShuttleSpawner
{
    [SerializeField]
    private MYXA94Controller Template;
    
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
        MYXA94Controller mx = Instantiate(Template);
        Vector2 SpawnPoint = new Vector2(Random.Range(MinSpawnPoint.position.x, MaxSpawnPoint.position.x), MinSpawnPoint.position.y);
        mx.transform.position = SpawnPoint;
        LastSpawn = Time.time;
        SpawnTime = SpawnRate + Random.Range(MinSpawnRate, MaxSpawnRate);
        Amount -= 1;
    }
}
