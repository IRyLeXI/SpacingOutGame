using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public float MinSpawnRate, MaxSpawnRate;

    private float SpawnRate;

    private float LastSpawn;

    public Transform SpawnPoint;

    public MeteorScript Template;

    public float MinRotation, MaxRotation;

    public Vector2 MinSpeed, MaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        LastSpawn = Time.time;
        SpawnRate = Random.Range(MinSpawnRate, MaxSpawnRate);
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
        MeteorScript mt = Instantiate(Template);
        mt.transform.position = SpawnPoint.position;
        mt.RotationSpeed = Random.Range(MinRotation, MaxRotation);
        mt.Speed = new Vector2(Random.Range(MinSpeed.x, MaxSpeed.x), Random.Range(MinSpeed.y, MaxSpeed.y));
        LastSpawn = Time.time;
        SpawnRate = Random.Range(MinSpawnRate, MaxSpawnRate);
    }

    private bool IsReadyForSpawn()
    {
        return Time.time >= (LastSpawn + SpawnRate);
    }
}
