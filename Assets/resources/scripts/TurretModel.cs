using UnityEngine;
using UnityEditor;

public abstract class TurretModel {

    private int _baseDamage;
    private float _range;
    private float _fireRate;
    private string _prefabName;

    public TurretModel(int baseDamage, float range, float fireRate, string prefabName) {
        _baseDamage = baseDamage;
        _range = range;
        _fireRate = fireRate;
        _prefabName = prefabName;
    }

    public int BaseDamage {
        get { return _baseDamage; }
    }

    public float Range {
        get { return _range; }
    }

    public float FireRate {
        get { return _fireRate; }
    }

    public string PrefabName {
        get { return _prefabName; }
    }
}
