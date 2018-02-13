using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class RandPriority : IAimPriority {
    private const int MAX_INT = 15000;
    private string _initials = "R";
    public RandPriority() {

    }
    //Return null if nobody is within its range
    public EnemyController GetEnemy(TurretController t,float range)
    {
        Wave w = WaveSpawner.CurrentWave;

        List<EnemyController> enemiesInRange = new List<EnemyController>();
        foreach (EnemyController e in w.CurrentEnemies)
        {

            if (e.View.Instance != null){
                float distanceToEnemy = Utils.GetDistanceToEnemy(t, e);
                if (distanceToEnemy < range){
                    enemiesInRange.Add(e);
                }
            }

        }
        if (enemiesInRange.Count > 0)
        {
            int enemyIndex = Random.Range(0, enemiesInRange.Count - 1);
            Debug.Log("index = " + enemyIndex);
            return enemiesInRange[enemyIndex];
        }
        else return null;
        
        
    }
    public string GetInitials()
    {
        return _initials;
    }
}