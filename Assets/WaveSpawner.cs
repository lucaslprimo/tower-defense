using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float wavesInterval;
    [SerializeField] int startCountEnemies = 1;

    private int nextWaveCount;
    private float wavesCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(startCountEnemies);
    }

    private void SpawnWave(int enemiesCount)
    {
        for(int i=0; i< enemiesCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            nextWaveCount = enemiesCount+1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(wavesCooldown <= 0f)
        {
            SpawnWave(nextWaveCount);
            wavesCooldown = wavesInterval;
        }
        else
        {
            wavesCooldown -= Time.deltaTime;
        }
    }
}
