using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] float spawnRandFactor = 0.3f;
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] int numberOfEnemies = 12;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public GameObject GetLaserPrefab() { return laserPrefab; }
    public float GetSpawnInterval() { return spawnInterval; }
    public float GetSpawnRandFactor() { return spawnRandFactor; }
    public float GetEnemySpeed() { return enemySpeed; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public List<Vector2> GetWayPoints()
    {
        List<Vector2> wayPoints = new List<Vector2>();

        foreach (Transform child in pathPrefab.transform)
        {
            wayPoints.Add(child.transform.position);
        }

        return wayPoints;
    }

}
