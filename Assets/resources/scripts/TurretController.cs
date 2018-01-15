using UnityEngine;
using UnityEditor;

public class TurretController {

    [SerializeField]
    private EnemyController _target;

    private TurretModel _model;
    private TurretView _view;

    public TurretView View {
        get { return _view; }
    }

    public TurretController(TurretModel model, Vector3 spawnPosition, Transform node) {
        _model = new StandardTurret();
        _view = TurretFactory.InstantiateView(spawnPosition, node, _model.PrefabName, this);
        
    }


    /**
     * Si une cible existe => on vérifie qu'elle se trouve toujours à portée de la tourelle
     *      Si c'est le cas la tourelle va pivoter vers elle
     * Sinon on va chercher une cible
     * */
    public void Notify() {


        if(_target != null) {

            float distanceToEnemy = Utils.GetDistanceToEnemy(this, _target);

            if(distanceToEnemy < _model.Range) {
                _view.Rotate(_target);
            } else {
                _target = null;
            }
            
            
        } else {
            EnemyController e = GetNearestEnemy();

            if (e != null) {
                float distanceToEnemy = Utils.GetDistanceToEnemy(this, e);

                if (distanceToEnemy < _model.Range) {
                    _target = e;
                }
            }
        }    
    }

    private EnemyController GetNearestEnemy() {
        Wave w = WaveSpawner.CurrentWave;

        EnemyController nearestEnemy = null;
        EnemyController target = null;
        float shortestDistance = Mathf.Infinity;

        foreach(EnemyController e in w.CurrentEnemies) {
            float distanceToEnemy = Utils.GetDistanceToEnemy(this, e);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = e;
                
            }
        }

        return nearestEnemy;

    }
}
