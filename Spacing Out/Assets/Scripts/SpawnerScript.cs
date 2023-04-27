using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerScript : MonoBehaviour
{

    [SerializeField]
    protected float MinSpawnRate, MaxSpawnRate;

    [SerializeField]
    protected Transform MinSpawnPoint, MaxSpawnPoint;

    [SerializeField]
    protected int Amount=0; 
    
    protected float SpawnRate, LastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool IsReadyForSpawn()
    {
        return Time.time >= (LastSpawn + SpawnRate);
    }

    protected bool IsReadyForSpawnWithAmount()
    {
        return Time.time >= (LastSpawn + SpawnRate) && Amount>0;
    }
}
