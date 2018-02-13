using UnityEngine;
using System.Collections;

public class HeavyBullet : BulletModel {

    public HeavyBullet() 
        : base(40f, "Bullet", 100) {}

    public override int GetSpecificsDamages(StandardEnemy e) {
        return (int)(0.5 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(HeavyEnemy e) {
        return (int)(2.5 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(LightEnemy e) {
        return (int)(0.25 * this.BaseDamage);
    }
}
