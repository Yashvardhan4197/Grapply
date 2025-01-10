using UnityEngine;

public class EnemyController
{
    private EnemyView enemyView;

    public EnemyController(EnemyView enemyPrefab)
    {
        enemyView = Object.Instantiate(enemyPrefab);
        this.enemyView.SetController(this);
    }

    public Transform GetEnemyTransform()
    {
        return enemyView.transform;
    }

}