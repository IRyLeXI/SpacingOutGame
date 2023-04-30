using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private List<WaveTemplate> Waves;

    [SerializeField]
    private float DelayBetweenWaves;
    
    private float LastSpawn;

    private WaveTemplate CurrentWave;

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
        return CurrentWave.WaveTime <= 0 && (Time.time >= (LastSpawn + DelayBetweenWaves));
    }

    private void NextWave()
    {
        //Debug.Log(Waves.Count);
        if(Waves.Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        CurrentWave = Waves[0];
        CurrentWave.EnableWave();
        Waves.RemoveAt(0);
        LastSpawn = Time.time + CurrentWave.WaveTime;
    }
}
