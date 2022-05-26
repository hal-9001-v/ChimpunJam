using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool _onAwake;
    [SerializeField] bool _auto;
    [SerializeField] Round[] _rounds;

    EnemySpawner[] _spawners => FindObjectsOfType<EnemySpawner>();

    public int roundCount { get; private set; }

    int enemyCount = 0;

    public Action<int> roundStartAction;
    public Action<int> roundEndAction;

    private void Awake()
    {
        roundCount = 0;

        if (_onAwake)
        {
            StartRound();
        }
    }

    void SpawnEnemies(int number)
    {
        List<EnemySpawner> spawners = new(_spawners);

        for (int i = 0; i < number; i++)
        {
            if (spawners.Count == 0)
            {
                spawners = new(_spawners);
            }

            int newIndex = UnityEngine.Random.Range(0, spawners.Count);

            var newSpawner = spawners[newIndex];
            spawners.RemoveAt(newIndex);

            newSpawner.SpawnEnemy(RemoveEnemy);
        }
    }

    void RemoveEnemy()
    {
        enemyCount--;

        if (enemyCount == 0)
        {
            if (roundEndAction != null)
            {
                roundEndAction.Invoke(roundCount);
            }

            if (_auto)
            {
                StartRound();
            }
        }
    }

    void StartRound()
    {
        Round currentRound;
        if (roundCount < _rounds.Length)
        {
            currentRound = _rounds[roundCount];
        }
        else
        {
            currentRound = _rounds[_rounds.Length - 1];

            currentRound.waves += currentRound.waves / 2;
        }

        roundCount++;

        if (roundStartAction != null)
        {
            roundStartAction.Invoke(roundCount);
        }

        StartCoroutine(Spawn(currentRound));

    }

    IEnumerator Spawn(Round round)
    {
        for (int i = 0; i < round.waves; i++)
        {
            SpawnEnemies(round.enemiesInWave);

            enemyCount += round.enemiesInWave;

            yield return new WaitForSeconds(round.spawnDelay);
        }

    }



    [Serializable]
    class Round
    {
        public int waves;
        public int enemiesInWave;
        public float spawnDelay;

    }
}
