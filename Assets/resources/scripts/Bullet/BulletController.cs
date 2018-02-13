using UnityEngine;
using System.Collections;

public class BulletController : IObserver {

    private BulletModel _model;
    private BulletView _view;
    private EnemyController _target;

    public BulletModel Model {
        get { return _model; }
    }

    public BulletController(BulletModel model, Transform spawnPoint, EnemyController target,int turretLevel) {
        _model = model;
        _view = BulletFactory.InstantiateView(spawnPoint, _model.PrefabName, this);
        _target = target;
        _model.Level = turretLevel;
        _target.AddObserver(this);

    }

    public void Notify() {
        if(_target == null) {
            Destroy();
        } else {
            _view.MoveToTarget(_target, _model.Speed);
        }
    }

    public void HitTarget() {

        Destroy();

        _target.GetDamage(this);

    }

    public void Destroy() {
        if(_target != null) {
            _target.RemoveObserver(this);
        }
        _view.Die();

    }

    public void Update(IObservable o) {
        _target = null;

    }
}
