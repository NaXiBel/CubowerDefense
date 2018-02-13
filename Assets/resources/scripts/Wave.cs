using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour, IObserver {

    private int _numberOfEnemies = 0;
    private List<EnemyController> _currentEnemies;
    private List<EnemyModel> _waveComponents;
    private float _countdown = 2f;
    private bool _finished;
    private GameObject _instance;

    private int _enemyTotal;
    private int _enemySpawned;

    public GameObject Instance {
        set { _instance = value; }
    }

    public List<EnemyController> CurrentEnemies {
        get { return _currentEnemies; }
    }
    public void InitializeWave(List<EnemyModel> enemies) {
        _waveComponents = enemies;
        _enemyTotal = _waveComponents.Count;
        Debug.Log("Dans wave : enemyTotal =" + _enemyTotal);

    }
    
    public bool isFinished() {
        return _finished;
    }

    void Awake() {
        _currentEnemies = new List<EnemyController>();
        _finished = false;
        _enemySpawned = 0;
    }
    void Update() {

        if(_enemySpawned < _enemyTotal  && _countdown <= 0f) {
            Spawn(_waveComponents[_enemySpawned]);
            _enemySpawned++; 
            _countdown = 1f;
        } 

        _countdown -= Time.deltaTime;
        

    }

    private void Spawn(EnemyModel em) {

        EnemyController enemy = new EnemyController(em);
        enemy.AddObserver(this);

        _currentEnemies.Add(enemy);
        _numberOfEnemies++;
        
    }


    public void Update(IObservable o) {

        if (_numberOfEnemies >= 1) {
            _currentEnemies.Remove((EnemyController)o);
            --_numberOfEnemies;
            o = null;
        }

        if(_numberOfEnemies == 0 && _enemySpawned == _enemyTotal){
            _finished = true;
        }
        
    }

    public void Die() {
        Destroy(_instance);
        foreach(EnemyController e in _currentEnemies)
        {
            e.Die();
        }
        _currentEnemies.Clear();
    }
}
