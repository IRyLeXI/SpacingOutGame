using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYXA94Spawner : SpawnerScript
{
    [SerializeField]
    private MYXA94Controller Template;

    private float thisSpawnRate;

    // Start is called before the first frame update
    void Start()
    {
        LastSpawn = Time.time;
        thisSpawnRate = 20f / (float)Amount;
        SpawnRate = thisSpawnRate + Random.Range(MinSpawnRate, MaxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReadyForSpawnWithAmount())
        {
            SpawnMYXA();
        }
    }

    private void SpawnMYXA()
    {
        MYXA94Controller mx = Instantiate(Template);
        Vector2 SpawnPoint = new Vector2(Random.Range(MinSpawnPoint.position.x, MaxSpawnPoint.position.x), MinSpawnPoint.position.y);
        mx.transform.position = SpawnPoint;
        LastSpawn = Time.time;
        SpawnRate = thisSpawnRate + Random.Range(MinSpawnRate, MaxSpawnRate);
        Amount -= 1;
    }
}