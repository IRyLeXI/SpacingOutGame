using UnityEngine;

[System.Serializable]
public abstract class SpawnerScript : MonoBehaviour
{

    [SerializeField]
    protected float minSpawnRate, maxSpawnRate;

    [SerializeField]
    protected Transform minSpawnPoint, maxSpawnPoint;

    [SerializeField]
    protected int Amount=0; 

    [SerializeField]
    private bool isInfinite = false;
    
    protected float spawnTime, lastSpawn, spawnRate;

    protected bool IsReadyForSpawn()
    {
        return Time.time >= (lastSpawn + spawnTime);
    }

    protected bool IsReadyForSpawnWithAmount()
    {
        return Time.time >= (lastSpawn + spawnTime) && (Amount>0 || isInfinite);
    }

    public void SetSpawnRate(int amount, float time)
    {
        Amount = amount;
        spawnRate = time / (float)Amount;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void SetPosition(Vector2 minSP, Vector2 maxSP)
    {
        minSpawnPoint.position = minSP;
        maxSpawnPoint.position = maxSP;
    }

}
