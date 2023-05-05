using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private List<WaveTemplate> Waves;

    [SerializeField]
    private float delayBetweenWaves;
    
    private float lastSpawn;

    private WaveTemplate currentWave;

    [SerializeField]
    private UnityEvent<int> nextWave;

    public int Wave;

    void Start()
    {
        Wave = 1;
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
        if(nextWave!=null)
            nextWave.Invoke(Wave);
        if(Waves.Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        currentWave = Waves[0];
        currentWave.EnableWave();
        Waves.RemoveAt(0);
        lastSpawn = Time.time + currentWave.waveTime;
        Wave++;
    }

    private bool IsEnemiesLeft()
    { 
        IEnemyShuttle[] enemies = FindObjectsOfType<MonoBehaviour>().OfType<IEnemyShuttle>().ToArray();
        if(enemies.Length == 0) lastSpawn = Time.time;
        return enemies.Length > 0;
    }



}
