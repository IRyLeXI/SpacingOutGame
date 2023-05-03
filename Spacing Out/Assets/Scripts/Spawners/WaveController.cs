using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private List<WaveTemplate> Waves;

    [SerializeField]
    private float delayBetweenWaves;
    
    private float lastSpawn;

    private WaveTemplate currentWave;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if(IsReadyForNextWave() && !IsEnemiesLeft())
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

    private bool IsEnemiesLeft()
    { 
        IEnemyShuttle[] enemies = FindObjectsOfType<MonoBehaviour>().OfType<IEnemyShuttle>().ToArray();
        if(enemies.Length == 0) lastSpawn = Time.time;
        return enemies.Length > 0;
    }

}
