using UnityEngine;
using UnityEditor;

public abstract class TurretModel {

    private float _range;
    private float _fireRate;
    private string _prefabName;
    private BulletModel _bullet;
    private float _upgradeCoeff;
    private int _level;
    private int _price;
    private int _initialUpgrade=100;

    public TurretModel(float range, float fireRate, string prefabName, BulletModel bullet, int price) {
        _range = range;
        _fireRate = fireRate;
        _prefabName = prefabName;
        _bullet = bullet;
        _level = 1;
        _upgradeCoeff = 0.25f;
        _price = price;
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

    public BulletModel Bullet {
        get { return _bullet; }
    }
    public int Level {
        get { return _level; }
    }

    public void LevelUp(){
        _level++;
        _range = _range + (_range * (_upgradeCoeff/2));
        _fireRate = _fireRate + (_fireRate * (_upgradeCoeff/2));

    }
    public int SellPrice()
    {
        return _price / 2+10*_level;
    }
    public int Price {
        get { return _price; }
    }
    public int GetUpgradePrice()
    {
        return (_initialUpgrade / 4) * _level + _initialUpgrade;
    }
}
