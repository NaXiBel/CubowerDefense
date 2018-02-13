using UnityEngine;
using UnityEditor;

public class StandardEnemy : EnemyModel {

    public StandardEnemy() : base(100,10f,"Enemy") {}

    public override void SetDamage(BulletModel b) {

        this.Health = this.Health - b.GetSpecificsDamages(this);
    }
}
