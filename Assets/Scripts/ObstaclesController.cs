using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public List<GameObject> obstacles;

    [SerializeField] private float maxXPosition = 200f;
    [SerializeField] private float maxYPosition = 80f;
    [SerializeField] private float obstaclesToSpawn = 40f;
    [SerializeField] private float timeToSpawnNextSetOfObstacles = 10f;

    [SerializeField] private float stageDuration = 30f; // Duration of each stage in seconds
    [SerializeField] private float minTimeToSpawn = 1f; // Minimum time to spawn obstacles
    [SerializeField] private float minXPosition = 50f; // Minimum x position range

    private float _spawnTimer = 0f;
    private float _stageTimer = 0f;
    private int _stage = 1;

    private bool _finishedStages = false;

    void Update()
    {
        if (_finishedStages) return;
        
        _spawnTimer += Time.deltaTime;
        _stageTimer += Time.deltaTime;

        if (_spawnTimer >= timeToSpawnNextSetOfObstacles)
        {
            SpawnObstacles();
            _spawnTimer = 0f;
        }

        if (_stageTimer >= stageDuration)
        {
            AdvanceStage();
            _stageTimer = 0f;
        }
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-maxXPosition, maxXPosition), Random.Range(-maxYPosition, maxYPosition), transform.position.z);
            Instantiate(obstacles[Random.Range(0, obstacles.Count)], spawnPosition, Quaternion.identity, transform);
        }
    }

    void AdvanceStage()
    {
        _stage++;

        if (_stage == 11)
        {
            _finishedStages = true;
        }
        
        // Decrease the time to spawn next set of obstacles
        timeToSpawnNextSetOfObstacles = Mathf.Max(minTimeToSpawn, timeToSpawnNextSetOfObstacles - 1f);

        // Decrease the range of maxXPosition
        maxXPosition = Mathf.Max(minXPosition, maxXPosition - 20f);

        Debug.Log("Stage: " + _stage);
        Debug.Log("Next spawn time: " + timeToSpawnNextSetOfObstacles);
        Debug.Log("Max X Position: " + maxXPosition);
    }
}
