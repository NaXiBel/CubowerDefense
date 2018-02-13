using UnityEngine;
using System.Collections;

public class LightEnemy : EnemyModel {

    public LightEnemy() : base(75, 16f, "LightEnemy") {}

    public override void SetDamage(BulletModel b) {

        this.Health = this.Health - b.GetSpecificsDamages(this);
    }
}
