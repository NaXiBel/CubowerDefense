using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour, IObserver {

    private int _numberOfEnemies = 0;
    private List<Enemy> _currentEnemies;
    private Dictionary<GameObject, int> _waveComponents;
    private float _countdown = 2f;
    private bool _finished = true;

    private int _enemyTotal = 10;
    private int _enemySpawned = 0;


    public void InitializeWave(Dictionary<GameObject, int> enemies) {
        _currentEnemies = new List<Enemy>();
        _finished = false;
        _waveComponents = enemies;

    }

    public bool isFinished() {
        return _finished;
    }

    void Update() {

        if (_enemySpawned < _enemyTotal && _countdown <= 0f) {
            Spawn();
            _enemySpawned++;
            _countdown = 1f;
        }

        _countdown -= Time.deltaTime;


    }

    private void Spawn() {

        Enemy enemy = Enemy.Spawn();
        enemy.AddObserver(this);

        _currentEnemies.Add(enemy);
        _numberOfEnemies++;

    }


    public void Update(IObservable o) {
        Debug.Log("NumberOfEnemies : " + _numberOfEnemies);
        if (_numberOfEnemies > 1) {
            Debug.Log("Un ennemi a disparu ! ");
            _currentEnemies.Remove((Enemy)o);
            --_numberOfEnemies;
        } else {
            _finished = true;
            Debug.Log("La vague est terminée !");
        }

    }
}
