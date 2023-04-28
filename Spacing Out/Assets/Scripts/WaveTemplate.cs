using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTemplate : MonoBehaviour
{
    [SerializeField]
    public float WaveTime;

    // [SerializeField]
    // private List<IEnemyShuttleSpawner> Spawners;

    [SerializeField]
    private HS16Spawner HS16Spawner;

    [SerializeField]
    private SK09Spawner SK09Spawner;

    [SerializeField]
    private MYXA94Spawner MYXA94Spawner;

    [SerializeField]
    private List<int> Amounts;

    [SerializeField]
    public bool Enabled;

    // Start is called before the first frame update
    void Start()
    {
        // Spawners.Add(HS16Spawner);
        // Spawners.Add(SK09Spawner);
        // Spawners.Add(MYXA94Spawner);
    }

    // Update is called once per frame
    void Update()
    {
        if(Enabled)
            WaveTime-=Time.deltaTime;
    }

    public void DestroyWave()
    {
        Destroy(this.gameObject);
        Destroy(HS16Spawner.gameObject);
        Destroy(SK09Spawner.gameObject);
        Destroy(MYXA94Spawner.gameObject);
    }

    public void EnableWave()
    {
        Enabled = true;
        HS16Spawner = Instantiate(HS16Spawner);
        SK09Spawner = Instantiate(SK09Spawner);
        MYXA94Spawner = Instantiate(MYXA94Spawner);
        HS16Spawner.SetSpawnRate(Amounts[0], WaveTime);
        SK09Spawner.SetSpawnRate(Amounts[1], WaveTime);
        MYXA94Spawner.SetSpawnRate(Amounts[2], WaveTime);
    }
}
