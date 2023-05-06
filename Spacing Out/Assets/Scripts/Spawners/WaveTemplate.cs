using System.Collections.Generic;
using UnityEngine;

public class WaveTemplate : MonoBehaviour, IFreezable
{
    [SerializeField]
    public float waveTime;

    [SerializeField]
    private List<SpawnerScript> Spawners;

    [SerializeField]
    private List<int> Amounts;

    //private List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private bool Enabled, isEndless = false;

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

    public virtual void EnableWave()
    {
        Enabled = true;
        int i = 0;
        foreach(SpawnerScript obj in Spawners)
        {
            var Obj = Instantiate(obj);
            if(!isEndless)
                Obj.SetSpawnRate(Amounts[i], waveTime);
            //spawnedObjects.Add(Obj.gameObject);
            i++;
        }
    }

    public void Freeze(float freezeTime)
    {
        waveTime += freezeTime;
    }
}
