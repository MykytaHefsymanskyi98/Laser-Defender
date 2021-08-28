using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //conf param
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] bool looping = false;

    //states

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));


        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemy(), waveConfig.GetPath()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }
}
