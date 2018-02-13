using UnityEngine;
using System.Collections;

public abstract class BulletModel {

    private float _speed;
    private string _prefabName;
    private int _baseDamage;
    private int _level;
    private float _damageCoeff;

    public BulletModel(float speed, string prefab, int damage) {
        _speed = speed;
        _prefabName = prefab;
        _baseDamage = damage;
        _damageCoeff = 0.20f;
    }


    public float Speed {
        get { return _speed; }
    }

    public string PrefabName {
        get { return _prefabName; }
    }

    public float BaseDamage {
        get {
            return _baseDamage + ((_level - 1)*_damageCoeff);
        }
    }

    public int Level {
        set { _level = value; }
    }




    /**
     * Chaque objet Bullet inflige des dégâts spécifiques selon les types
     * d'ennemis touchés.
     * 
     * */
    public abstract int GetSpecificsDamages(StandardEnemy e);

    public abstract int GetSpecificsDamages(HeavyEnemy e);

    public abstract int GetSpecificsDamages(LightEnemy e);


}
