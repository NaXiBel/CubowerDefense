using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController :IObservable{

    private EnemyModel _enemyModel;
    private Wave _wave = null;
    private EnemyView _enemyView;
    private int _wavepointIndex = 0;

    
    public EnemyController(EnemyModel enemyType, Wave wave) {
        _enemyModel = enemyType;
        _wave = wave;
        _enemyView = EnemyFactory.InstantiateView(WaveSpawner.GetSpawnPoint(), enemyType.PrefabName,this);
    }

    public EnemyView View {
        get { return _enemyView; }
    }

    /**
     * L'ennemi est en attente s'il est arrivé au waypoint prévu 
     * */
    public void Move() {
        if (_enemyView.IsWaiting) {
            if (_wavepointIndex >= Waypoints.GetNumberOfWaypoints()) {
                NotifyObservers();
                _enemyView.Die();


            } else {
                _enemyView.Move(Waypoints.GetWaypoints(_wavepointIndex), _enemyModel.Speed);
                ++_wavepointIndex;
            }
        }else _enemyView.Move(Waypoints.GetWaypoints(_wavepointIndex-1), _enemyModel.Speed);



    }

    public void Notify() {
        Move();
        
    }

    public void AddObserver(IObserver o) {
        if(_wave == null) {
            _wave = (Wave)o;
            
        }
    }

    public void RemoveObserver(IObserver o) {
        if(_wave != null) {
            _wave = null;
        }
    }

    public void NotifyObservers() {
        _wave.Update((this));
    }
}
