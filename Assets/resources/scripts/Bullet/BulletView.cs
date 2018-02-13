using UnityEngine;
using System.Collections;

public class BulletView : MonoBehaviour {

    private BulletController _controller;
    private GameObject _instance;


    public BulletController Controller {
        set { _controller = value; }
    }

    public GameObject Instance {
        set { _instance = value; }
    }
    // Update is called once per frame
    void Update() {
        _controller.Notify();

    }

    public void MoveToTarget(EnemyController target, float speed) {

        if(target.View != null) {
            Vector3 direction = target.View.Position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame) {
                _controller.HitTarget();
            } else {
                transform.Translate(direction.normalized * distanceThisFrame, Space.World);
            }

        }

    }

    public void Die() {
        Destroy(_instance);
    }
}
