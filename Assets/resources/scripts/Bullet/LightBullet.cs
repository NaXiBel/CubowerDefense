using UnityEngine;
using System.Collections;

public class LightBullet : BulletModel {

    public LightBullet()
        : base(85f, "Bullet", 25) { }

    
    public override int GetSpecificsDamages(StandardEnemy e) {
        return (int)(0.8 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(HeavyEnemy e) {
        return (int)(0.6 * this.BaseDamage);
    }

    public override int GetSpecificsDamages(LightEnemy e) {
        return (int)(2.5 * this.BaseDamage);
    }
}