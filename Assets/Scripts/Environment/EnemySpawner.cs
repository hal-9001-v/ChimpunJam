using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    EnemyPrototypeProvider _enemyProvider => FindObjectOfType<EnemyPrototypeProvider>();

    enum EnemyType
    {
        Fast,
        Slow,
        Shooter
    }

    [ContextMenu("Spawn Enemy")]
    public void SpawnEnemy()
    {
        SpawnEnemy(null);
    }
    
    public void SpawnEnemy(Action deadAction)
    {
        var clone = _enemyProvider.GetRandomEnemy();

        clone.transform.position = transform.position;

        clone.EnableEnemy();

        if (deadAction != null)
        {
            clone.health.deadAction += (pos, push, hitter) =>
            {
                deadAction.Invoke();
            };
        }

        clone.transform.parent = transform;

    }



}
