using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretView : MonoBehaviour {


    private TurretController _controller;
    private Transform _partToRotate;


    private float _turnSpeed = 10f;


    public TurretController Controller {
        set { _controller = value; }
    }
    public Vector3 Position {
        get { return transform.position; }
    }

    void Start() {
        _partToRotate = transform.GetChild(1);
    }

    void Update() {
        _controller.Notify();
    }



    public void Rotate(EnemyController target) {

        if (target != null) {
            Vector3 direction = target.View.Position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
            _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }

    }

    public void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }


}
