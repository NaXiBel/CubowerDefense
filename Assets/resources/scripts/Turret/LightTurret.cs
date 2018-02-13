using UnityEngine;
using System.Collections;

public class LightTurret : TurretModel {
    public LightTurret() 
        : base(8f, 1.5f, "LightTurret", new LightBullet(),80) {}
}
