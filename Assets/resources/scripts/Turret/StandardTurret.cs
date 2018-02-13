using UnityEngine;
using UnityEditor;


public class StandardTurret : TurretModel {
	public StandardTurret()
        : base (10f, 1f, "Turret", new StandardBullet(),150) {}

}
