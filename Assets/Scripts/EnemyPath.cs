using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // conf param
    WaveConfig waveConfig;
    List<Transform> enemyPath;
    int wayPointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyPath = waveConfig.GetPath();
        transform.position = enemyPath[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= enemyPath.Count - 1)
        {
            var targetPosition = enemyPath[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
