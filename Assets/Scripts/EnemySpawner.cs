using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        } while (looping);
        
    }

    IEnumerator SpawnWaves ()
    {
        for (int i = 0; i < waveConfigs.Count; i++)
        {
            yield return StartCoroutine(SpawnEnemies(waveConfigs[i]));
        }
    }

    IEnumerator SpawnEnemies(WaveConfig wave) 
    {
        for (int i = 0; i < wave.GetNumberOfEnemies(); i++)
        {
            GameObject enemy = Instantiate<GameObject>(wave.GetEnemyPrefab(), wave.GetWayPoints()[0], Quaternion.identity);
            enemy.GetComponent<Enemy>().SetWaveConfig(wave);
            enemy.GetComponent<SpriteRenderer>().sprite = wave.GetEnemySprite();
            yield return new WaitForSeconds(wave.GetSpawnInterval());
        }
    }
}
