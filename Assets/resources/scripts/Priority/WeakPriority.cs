using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class WeakPriority : IAimPriority {
    private const int MAX_INT = 15000;
    private string _initials = "W";
    public WeakPriority() {

    }
    //Return null if nobody is within its range
    public EnemyController GetEnemy(TurretController t,float range)
    {
        Wave w = WaveSpawner.CurrentWave;

        EnemyController weakestEnemy = null;
        int enemyPV = MAX_INT;

        foreach (EnemyController e in w.CurrentEnemies)
        {

            if (e.View.Instance != null){
                float distanceToEnemy = Utils.GetDistanceToEnemy(t, e);
                if (distanceToEnemy < range){
                    if (enemyPV > e.GetHealth()){
                        weakestEnemy = e;
                    }
                }
            }

        }
        return weakestEnemy;
    }
    public string GetInitials()
    {
        return _initials;
    }

}