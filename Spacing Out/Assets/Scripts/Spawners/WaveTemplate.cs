using System.Collections.Generic;
using UnityEngine;

public class WaveTemplate : MonoBehaviour
{
    [SerializeField]
    public float waveTime;

    [SerializeField]
    private List<SpawnerScript> Spawners;

    [SerializeField]
    private List<int> Amounts;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    public bool Enabled;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Enabled)
        {
            waveTime-=Time.deltaTime;
        }
        if(waveTime<0)
        {
            DestroyWave();
        }
    }

    public void DestroyWave()
    {
        Destroy(this.gameObject);
    }

    public void EnableWave()
    {
        Enabled = true;
        int i = 0;
        foreach(SpawnerScript obj in Spawners)
        {
            var Obj = Instantiate(obj);
            Obj.SetSpawnRate(Amounts[i], waveTime);
            spawnedObjects.Add(Obj.gameObject);
            i++;
        }
    }
}
