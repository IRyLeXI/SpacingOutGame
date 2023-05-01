using UnityEngine;

public class MeteorSpawner : SpawnerScript
{
    [SerializeField]
    private float minRotation = -90, maxRotation = 90;

    [SerializeField]
    private float minSpeedBig, maxSpeedBig, minSpeedSmall, maxSpeedSmall;

    [SerializeField]
    private Vector2 minDirection, maxDirection;

    [SerializeField]
    private MeteorScript[] Template;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawn = Time.time;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReadyForSpawn())
        {
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        MeteorScript mt = Instantiate(Template[Random.Range(0, Template.Length)]);
        Vector2 SpawnPoint = new Vector2(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), minSpawnPoint.position.y);
        mt.transform.position = SpawnPoint;
        mt.rotationSpeed = Random.Range(minRotation, maxRotation);
        if (mt.gameObject.tag == "BigMeteorite")
        {
            mt.pushForce = Random.Range(minSpeedBig, maxSpeedBig);
        }
        else
        {
            mt.pushForce = Random.Range(minSpeedSmall, maxSpeedSmall);
        }
        Vector2 direction = new Vector2(Random.Range(minDirection.x, maxDirection.x), Random.Range(minDirection.y, maxDirection.y));
        mt.pushDirection = direction;
        lastSpawn = Time.time;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }
}
