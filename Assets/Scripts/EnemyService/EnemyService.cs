
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    private EnemyPool enemyPool;
    private List<Transform> currentlySpawnedEnemies;
    private bool isGameRunning;
    [SerializeField] float enemyRadius;
    [SerializeField] float totalEnemies;
    [SerializeField] EnemyView enemyPrefab;
    private void Awake()
    {
        //change to constructor later
        Init();
    }

    public void Init()
    {
        enemyPool = new EnemyPool(enemyPrefab);
        currentlySpawnedEnemies = new List<Transform>();
    }

    public void OnGameStart()
    {
        currentlySpawnedEnemies.Clear();
        isGameRunning = true;

        while(currentlySpawnedEnemies.Count<3)
        {
            SpawnEnemy();
        }
        
    }


    public void SpawnEnemy()
    {
        EnemyController newEnemyController= enemyPool.GetPooledItem();
        currentlySpawnedEnemies.Add(newEnemyController.GetEnemyTransform());
        newEnemyController.GetEnemyTransform().position = CheckValidPosition();
    }

    private Vector2 CheckValidPosition()
    {
        bool check;
        Vector2 scrrenPos= new Vector2(Random.Range(0,Screen.width), Random.Range(0,Screen.height));
        Vector2 newPos=Camera.main.ScreenToWorldPoint(scrrenPos);
        int attempts = 100;
        do
        {
            check = true;
            foreach (Transform enemyPos in currentlySpawnedEnemies)
            {
                if (Vector2.Distance(newPos, enemyPos.position) <= enemyRadius)
                {
                    check = false;
                }
            }
            attempts--;
        }
        while(check&&attempts>0);
        return newPos;
    }


    public void ReturnToPool(EnemyController enemyController)
    {
        if(currentlySpawnedEnemies.Contains(enemyController.GetEnemyTransform()))
        {
            currentlySpawnedEnemies.Remove(enemyController.GetEnemyTransform());
        }
        enemyPool.ReturnToPool(enemyController);
        
    }

}
