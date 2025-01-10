using UnityEngine;

public class EnemyView: MonoBehaviour
{
    private EnemyController enemyController;

    public void SetController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}