using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObservable{


    private float _speed = 10f;
    private Wave _wave = null;
    private Transform _target;
    private int _wavepointIndex = 0;
    private static GameObject _prefab;

    
    // Use this for initialization
    void Start() {

        
        _target = Waypoints.GetWaypoints(0);
    }


    void Update() {


        MoveToNextWaypoint();


    }

    private void MoveToNextWaypoint() {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.2f) {
            GetNextWaypoint();
        }
    }

    public static Enemy Spawn() {

        _prefab = ((GameObject)Resources.Load("prefabs/Enemy", typeof(GameObject)));
        Transform spawnPoint = WaveSpawner.GetSpawnPoint();
        return Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation).GetComponent<Enemy>();
    }

    private void GetNextWaypoint() {

        if (_wavepointIndex >= Waypoints.GetNumberOfWaypoints() - 1) {
            NotifyObservers();
            Destroy(gameObject);
            
        } else {
            ++_wavepointIndex;
            _target = Waypoints.GetWaypoints(_wavepointIndex);
        }

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
