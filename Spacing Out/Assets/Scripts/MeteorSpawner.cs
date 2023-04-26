using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MeteorScript
{
    [SerializeField]
    private float MinSpawnRate, MaxSpawnRate;

    private float SpawnRate;

    private float LastSpawn;

    [SerializeField]
    private Transform MinSpawnPoint, MaxSpawnPoint;

    [SerializeField]
    private float MinRotation = -90, MaxRotation = 90;

    [SerializeField]
    private float MinSpeedBig, MaxSpeedBig, MinSpeedSmall, MaxSpeedSmall;

    [SerializeField]
    private Vector2 MinDirection, MaxDirection;

    [SerializeField]
    private MeteorScript[] Template;
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
        MeteorScript mt = Instantiate(Template[Random.Range(0, Template.Length)]);
        Vector2 SpawnPoint = new Vector2(Random.Range(MinSpawnPoint.position.x, MaxSpawnPoint.position.x), MinSpawnPoint.position.y);
        mt.transform.position = SpawnPoint;
        mt.RotationSpeed = Random.Range(MinRotation, MaxRotation);
        if (mt.gameObject.tag == "BigMeteorite")
        {
            mt.pushForce = Random.Range(MinSpeedBig, MaxSpeedBig);
        }
        else
        {
            mt.pushForce = Random.Range(MinSpeedSmall, MaxSpeedSmall);
        }
        Vector2 direction = new Vector2(Random.Range(MinDirection.x, MaxDirection.x), Random.Range(MinDirection.y, MaxDirection.y));
        mt.pushDirection = direction;
        LastSpawn = Time.time;
        SpawnRate = Random.Range(MinSpawnRate, MaxSpawnRate);
    }

    private bool IsReadyForSpawn()
    {
        return Time.time >= (LastSpawn + SpawnRate);
    }
}
