using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class EnemySpawner : MonoBehaviour
{
    Level level;
    [ShowInInspector]List<WaveConfig> WaveConfigs;
    [ShowInInspector]List<float> timestamps;
    [SerializeField] UnityEvent EnemySpawned;
    [SerializeField] UnityEvent AllWavesSpawned;
    [SerializeField] bool looping = false;
    [ReadOnly]float currentTime;
    int startingWave;
    
    // Use this for initialization


    public IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(spawnAllWaves());
        }
        while (looping);
    }


    private void Update()
    {
        if (WaveConfigs == null)
        {
            level = Level._currentLevel;
            WaveConfigs = level.GetLevelScript().GetWaveConfigs();
            timestamps = level.GetLevelScript().GetTimestamps();

        }
        currentTime += Time.deltaTime;
    }

    public IEnumerator spawnAllWaves()
    {
        for (int waveIndex = 0; waveIndex <= WaveConfigs.Count-1; waveIndex++)
        {
            var currentWave = WaveConfigs[waveIndex];

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave, waveIndex));

        }
        
        yield return new WaitForSeconds(5);
        AllWavesSpawned.Invoke();
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig, int waveIndex)
    {
        yield return new WaitForSeconds(timestamps[waveIndex] - currentTime);

            
            
            Debug.Log(WaveConfigs[waveIndex]);

            for (int i = 0; i <= waveConfig.GetNumOfEnemies(); i++)
            {
                GameObject enemy = Instantiate(waveConfig.GetEnemy());
                enemy.transform.position = waveConfig.GetStartPos();
                enemy.GetComponent<PathMoverSimple>().SetPath(waveConfig.GetPath());
                enemy.GetComponent<PathMoverSimple>().setWaypoints();
                enemy.GetComponent<PathMoverSimple>().SetSpeed(waveConfig.GetSpeed());
                EnemySpawned.Invoke();
                yield return new WaitForSeconds(waveConfig.GetSpawnInterval());
            }
         


    }

    public void setScript(Level level)
    {
        this.level = level;
        WaveConfigs = level.GetLevelScript().GetWaveConfigs();
        timestamps = level.GetLevelScript().GetTimestamps();
    }
}
