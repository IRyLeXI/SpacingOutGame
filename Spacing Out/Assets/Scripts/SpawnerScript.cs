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

    [SerializeField]
    private bool isInfinite = false;
    
    protected float SpawnTime, LastSpawn, SpawnRate;

    protected bool IsReadyForSpawn()
    {
        return Time.time >= (LastSpawn + SpawnTime);
    }

    protected bool IsReadyForSpawnWithAmount()
    {
        return Time.time >= (LastSpawn + SpawnTime) && (Amount>0 || isInfinite);
    }

    public void SetSpawnRate(int amount, float time)
    {
        Amount = amount;
        SpawnRate = time / (float)Amount;
    }
}
