using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Config")]
public class WaveConfig : ScriptableObject
{
    //conf param
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject path;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandom = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 5f;

    public GameObject GetEnemy()
    {
        return enemyPrefab;
    }

    public List<Transform> GetPath()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in path.transform)
        {
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandom()
    {
        return spawnRandom;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
