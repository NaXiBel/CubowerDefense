using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class StrongPriority : IAimPriority {
    private string _initials = "S";
    public StrongPriority() {

    }
    //Return null if nobody is within its range
    public EnemyController GetEnemy(TurretController t,float range)
    {
        Wave w = WaveSpawner.CurrentWave;

        EnemyController strongestEnemy = null;
        int enemyPV = 0;

        foreach (EnemyController e in w.CurrentEnemies)
        {

            if (e.View.Instance != null){
                float distanceToEnemy = Utils.GetDistanceToEnemy(t, e);
                if (distanceToEnemy < range){
                    if (enemyPV < e.GetHealth()){
                        strongestEnemy = e;
                    }
                   
                }
            }

        }
        return strongestEnemy;
    }
    public string GetInitials()
    {
        return _initials;
    }
}