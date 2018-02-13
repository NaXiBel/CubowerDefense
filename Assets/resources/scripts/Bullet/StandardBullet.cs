using UnityEngine;
using System.Collections;

public class StandardBullet : BulletModel {

    public StandardBullet() : base(70f, "Bullet", 60) {}

    public override int GetSpecificsDamages(StandardEnemy e) {
        return (int)(1 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(HeavyEnemy e) {
        return (int)(0.8 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(LightEnemy e) {
        return (int)(0.8 * this.BaseDamage);
    }
}
