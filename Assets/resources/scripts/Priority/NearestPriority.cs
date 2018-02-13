using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class NearestPriority : IAimPriority {

    private string _initials = "N";

    public NearestPriority() {

    }

    public EnemyController GetEnemy(TurretController t,float range)
    {
        Wave w = WaveSpawner.CurrentWave;

        EnemyController nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (EnemyController e in w.CurrentEnemies)
        {

            if (e.View.Instance != null)
            {
                float distanceToEnemy = Utils.GetDistanceToEnemy(t, e);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = e;

                }
            }

        }

        return nearestEnemy;
    }

    public string GetInitials()
    {
        return _initials;
    }
    
}