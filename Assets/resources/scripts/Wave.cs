using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour, IObserver {

    private int _numberOfEnemies = 0;
    private List<Enemy> _currentEnemies;
    private Dictionary<GameObject, int> _waveComponents;
    private float _countdown = 2f;
    private bool _finished = true;


    public void InitializeWave(Dictionary<GameObject, int> enemies) {
        _currentEnemies = new List<Enemy>();
        _finished = false;
        _waveComponents = enemies;

    }
    
    public bool isFinished() {
        return _finished;
    }

    void Update() {

        if(_countdown <= 0f) {
            Spawn();
            _countdown = 1f;
        }

        _countdown -= Time.deltaTime;
        

    }

    private void Spawn() {

        Dictionary<GameObject, int>.KeyCollection keyColl = _waveComponents.Keys;
        Transform spawnPoint = WaveSpawner.GetSpawnPoint();
        foreach (GameObject g in keyColl) {
            Enemy enemy = Enemy.Spawn();
            enemy.AddObserver(this);

            _currentEnemies.Add(enemy);
            _numberOfEnemies++;
        }
    }


    public void Update(IObservable o) {
        Debug.Log("Un ennemi a disparu ! ");
        _currentEnemies.Remove((Enemy)o);
        --_numberOfEnemies;
    }
}
