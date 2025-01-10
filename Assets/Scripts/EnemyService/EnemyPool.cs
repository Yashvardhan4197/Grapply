﻿using System;
using System.Collections.Generic;

public class EnemyPool
{
    private EnemyView enemyPrefab;
    private List<PooledItem> pooledItems=new List<PooledItem>();

    public EnemyPool(EnemyView enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
    }

    public EnemyController GetPooledItem()
    {
        PooledItem item = pooledItems.Find(i => !i.isUsed);
        if(item!=null)
        {
            item.isUsed = true;
            return item.enemyController;
        }
        return CreateItem();
    }

    private EnemyController CreateItem()
    {
        PooledItem newItem= new PooledItem();
        newItem.isUsed = true;
        newItem.enemyController=new EnemyController(enemyPrefab);
        pooledItems.Add(newItem);
        return newItem.enemyController;
    }

    public void ReturnToPool(EnemyController enemyController)
    {
        PooledItem item=pooledItems.Find(item=>item.enemyController==enemyController);
        if(item!=null)
        {
            item.isUsed = false;
        }
    }


    public class PooledItem
    {
        public EnemyController enemyController;
        public bool isUsed;
    }

}