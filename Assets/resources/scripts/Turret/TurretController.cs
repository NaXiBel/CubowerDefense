using UnityEngine;
using UnityEditor;

public class TurretController {

    [SerializeField]
    private EnemyController _target;

    private TurretModel _model;
    private TurretView _view;
    private float _fireCountdown;
    private IAimPriority _aimType;
    private bool _aimHasChanged = false;

    public TurretView View {
        get { return _view; }
    }

    public IAimPriority AimType {
        get { return _aimType; }
        set { _aimType = value;
            _aimHasChanged = true;
        }
    }
    public bool AimHasChanged {
        get{ return _aimHasChanged; }
        set{ _aimHasChanged = value; }
    }

    public TurretController(TurretModel model, Vector3 spawnPosition, Transform node) {
        _model = model;
        _view = TurretFactory.InstantiateView(spawnPosition, node, _model.PrefabName, this);
        _fireCountdown = 0f;
        _aimType = new NearestPriority();
        
    }


    /**
     * Si une cible existe => on vérifie qu'elle se trouve toujours à portée de la tourelle
     *      Si c'est le cas la tourelle va pivoter vers elle
     * Sinon on va chercher une cible
     * */
    public void Notify() {


        if(_target != null && _target.View.Instance != null) { 

            float distanceToEnemy = Utils.GetDistanceToEnemy(this, _target);

            if(distanceToEnemy < _model.Range) {
                _view.Rotate(_target);

                if(_fireCountdown <= 0f) {
                    Shoot();
                    _fireCountdown = 1f / _model.FireRate;
                }
            _fireCountdown -= Time.deltaTime;
            } else {
                _target = null;
            }

            
            
        } else {
            EnemyController e = _aimType.GetEnemy(this,_model.Range);

            if (e != null) {
                float distanceToEnemy = Utils.GetDistanceToEnemy(this, e);

                if (distanceToEnemy < _model.Range) {
                    _target = e;
                }
            }
        }    
    }


    private void Shoot() {
        BulletController b = new BulletController(_model.Bullet, _view.FirePoint, _target,_model.Level);
        _view.ShootUI();
        _target = null;
    }

    public int Upgrade(){
        int rst = GameController.Pay(_model.GetUpgradePrice());
        if(rst != -1){
            _model.LevelUp();
            _view.UpdateRange();
        }
        return rst;
    }

    public int GetPrice()
    {
        return _model.Price;
    }

    public int GetSellPrice()
    {
        return _model.SellPrice();
    }

    public void Sell()
    {
        GameController.GainMoney(_model.SellPrice());
        _view.Die();
    }
    public int GetUpgradePrice(){
        return _model.GetUpgradePrice();
    }

    public float GetRange(){
        return _model.Range;
    }
}
