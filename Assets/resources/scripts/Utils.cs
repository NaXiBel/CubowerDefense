using UnityEngine;
using UnityEngine.UI;

class Utils {

    public static float GetDistanceToEnemy(TurretController t, EnemyController e) {
      
        return Vector3.Distance(t.View.Position, e.View.Position);
    }

    public static Color GetHoverColor(Color sel)
    {
        float r, g, b, a;
        r = (float)sel.r * 2;
        g = (float)sel.g * 2;
        b = (float)sel.b * 2;

        return new Color(r, g, b, sel.a);
    }

    public static Color GetErrorColor(Color sel)
    {
        float r, g, b, a;
        r = (float)sel.r * 5;
        g = (float)sel.g;
        b = (float)sel.b;

        return new Color(r, g, b, sel.a);
    }
}