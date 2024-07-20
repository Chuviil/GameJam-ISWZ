using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    
    [SerializeField] private UnityEvent onFinishedStages;
    
    [SerializeField] private TMP_Text stageText;

    private float _spawnTimer = 0f;
    private float _stageTimer = 0f;
    private int _stage = 1;

    private bool _finishedStages = false;
    private bool _started = false;
    
    void Update()
    {
        if(!_started) return;
        
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
            onFinishedStages?.Invoke();
            stageText.SetText("0");
            return;
        }
        
        stageText.SetText(_stage.ToString());
        
        // Decrease the time to spawn next set of obstacles
        timeToSpawnNextSetOfObstacles = Mathf.Max(minTimeToSpawn, timeToSpawnNextSetOfObstacles - 1f);

        // Decrease the range of maxXPosition
        maxXPosition = Mathf.Max(minXPosition, maxXPosition - 20f);
    }

    public void StartGame()
    {
        _started = true;
    }
}
