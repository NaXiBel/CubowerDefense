using UnityEngine;
using System.Collections;

public class HeavyTurret : TurretModel {
    public HeavyTurret() 
        : base(20f, 0.6f, "HeavyTurret", new HeavyBullet(),200) {}
}
