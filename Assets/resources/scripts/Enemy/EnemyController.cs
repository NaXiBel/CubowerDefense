using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController :IObservable{

    private EnemyModel _enemyModel;
    private List<IObserver> _obs;
    private EnemyView _enemyView;
    private int _wavepointIndex = 0;

    
    public EnemyController(EnemyModel enemyType) {
        _obs = new List<IObserver>();
        _enemyModel = enemyType;
        _enemyView = EnemyFactory.InstantiateView(WaveSpawner.GetSpawnPoint(), enemyType.PrefabName,this);
    }

    public EnemyView View {
        get { return _enemyView; }
    }

    public int GetHealth() {
        return _enemyModel.Health;
    }

    public int GetStartHealth()
    {
        return _enemyModel.StartHealth;
    }

    public EnemyModel Model {
        get { return _enemyModel; }
    }

    /**
     * L'ennemi est en attente s'il est arrivé au waypoint prévu 
     * */
    public void Move() {


        if(_enemyModel.Health > 0) {
            if (_enemyView.IsWaiting) {
                if (_wavepointIndex >= Waypoints.GetNumberOfWaypoints()) {
                    //L'ennemi est arrivé au point de fin
                    NotifyObservers();
                    _enemyView.Die();
                    GameController.HealthDown();


                } else {
                    _enemyView.Move(Waypoints.GetWaypoints(_wavepointIndex), _enemyModel.Speed);
                    ++_wavepointIndex;
                }
            } else _enemyView.Move(Waypoints.GetWaypoints(_wavepointIndex - 1), _enemyModel.Speed);

        } else {
            //L'ennemi à été tué
            NotifyObservers();
            Die();
            GameData.Money = GameData.Money + 5;
        }


    }

    public void Notify() {
        Move();
        
    }

    public void GetDamage(BulletController b) {
        _enemyModel.SetDamage(b.Model);
    }

    public void AddObserver(IObserver o) {
        _obs.Add(o);
    }

    public void RemoveObserver(IObserver o) {
        _obs.Remove(o);
    }

    public void NotifyObservers() {
        foreach(IObserver o in _obs) {
            o.Update(this);
        }
    }

    public void Die()
    {
        _enemyView.Die();
    }


}
