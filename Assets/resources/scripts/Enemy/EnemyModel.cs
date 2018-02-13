using UnityEngine;
using UnityEditor;

public abstract class EnemyModel {
    private int _health;
    private int _startHealth;
    private float _speed;
    private string _prefabName;

    public EnemyModel(int pv, float speed, string prefab) {
        _health = pv;
        _startHealth = pv;
        _speed = speed;
        _prefabName = prefab;

    }

    public int Health {
        get { return _health; }
        set { _health = value; }
    }

    public int StartHealth {
        get { return _startHealth; }
    }
    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    public string PrefabName {
        get { return _prefabName; }
        set { _prefabName = value; }
    }

    

    public abstract void SetDamage(BulletModel b);



}