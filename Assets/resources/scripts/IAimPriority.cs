using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public interface IAimPriority {
    
    EnemyController GetEnemy(TurretController t,float range);
    string GetInitials();

}