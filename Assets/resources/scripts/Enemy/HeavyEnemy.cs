using UnityEngine;
using System.Collections;

public class HeavyEnemy : EnemyModel {
    public HeavyEnemy() : base(400, 7f, "HeavyEnemy") {}

    public override void SetDamage(BulletModel b) {

        this.Health = this.Health - b.GetSpecificsDamages(this);
    }
}
