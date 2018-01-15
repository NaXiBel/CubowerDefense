using UnityEngine;
using UnityEngine.UI;

class Utils {

    public static float GetDistanceToEnemy(TurretController t, EnemyController e) {
      
        return Vector3.Distance(t.View.Position, e.View.Position);
    }
}