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
    protected bool isInfinite = false;
    
    protected float lastSpawn, spawnRate;

    protected GameController gameController;

    protected virtual void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    protected bool IsReadyForSpawn()
    {
        return Time.time >= (lastSpawn + spawnRate);
    }

    protected bool IsReadyForSpawnWithAmount()
    {
        return Time.time >= (lastSpawn + spawnRate) && (Amount>0 || isInfinite);
    }

    public void SetSpawnRate(int amount, float time)
    {
        Amount = amount;
        spawnRate = time / (float)Amount;
        minSpawnRate = spawnRate;
        maxSpawnRate = spawnRate;
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
