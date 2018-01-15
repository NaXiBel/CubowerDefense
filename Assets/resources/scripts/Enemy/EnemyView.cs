using UnityEngine;
using UnityEditor;

public class EnemyView : MonoBehaviour {

    private Transform _graphicalWaypoint;
    private GameObject _instance;
    private EnemyController _enemyController;
    private bool _isWaiting = true;

    public Vector3 Position {
        get { return transform.position; }
    }

    public EnemyController Controller {
        set { _enemyController = value; }
    }

    public bool IsWaiting {
        get { return _isWaiting; }
    }

    void Update() {
        if (null != _graphicalWaypoint && Vector3.Distance(transform.position, _graphicalWaypoint.position) <= 0.2f) {
            _isWaiting = true;
        } else if (null == _graphicalWaypoint) {
            _isWaiting = true;
        } else _isWaiting = false;


        _enemyController.Notify();
    }
    public GameObject Instance {
        set{ _instance = value; }
    }

    public void Move(Transform nextWaypoint,float speed) {

        Vector3 direction = nextWaypoint.position - transform.position;
        _instance.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        _graphicalWaypoint = nextWaypoint;
        
    }

    public void Die() {
        Destroy(_instance);
    }


}