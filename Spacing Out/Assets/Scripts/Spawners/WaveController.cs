using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private List<WaveTemplate> Waves;

    [SerializeField]
    private float delayBetweenWaves;
    
    private float lastSpawn;

    private WaveTemplate currentWave;

    // Start is called before the first frame update
    void Start()
    {
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReadyForNextWave())
        {
            NextWave();
        }
    }

    private bool IsReadyForNextWave()
    {
        return currentWave.waveTime <= 0 && (Time.time >= (lastSpawn + delayBetweenWaves));
    }

    private void NextWave()
    {
        //Debug.Log(Waves.Count);
        if(Waves.Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        currentWave = Waves[0];
        currentWave.EnableWave();
        Waves.RemoveAt(0);
        lastSpawn = Time.time + currentWave.waveTime;
    }
}
