using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretView : MonoBehaviour {


    private TurretController _controller;
    private Transform _partToRotate;
    private Transform _firePoint;
    private GameObject _instance;
    private LineRenderer _lineR;

    private Color startColor;
    private Color hoverColor;
    private Renderer rend;

    private static AudioSource _sound;

    private float _turnSpeed = 10f;

    private static Text _priority;

    public TurretController Controller {
        set { _controller = value; }
    }
    public Vector3 Position {
        get { return transform.position; }
    }

    public Transform FirePoint {
        get { return _firePoint; }
    }

    public GameObject Instance {
        set { _instance = value; }
        get { return _instance; }
    }
    void Start() {
        _partToRotate = transform.GetChild(1);
        _firePoint = _partToRotate.transform.GetChild(1);
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        hoverColor = GetHoverColor();
        _sound = _instance.GetComponent<AudioSource>();

        _lineR = _instance.GetComponent<LineRenderer>();
        _lineR.SetVertexCount(51);
        _lineR.useWorldSpace = false;
        UpdateRange();
        _lineR.enabled = false;
    }

    void Update() {
        _controller.Notify();
        if (_controller.AimHasChanged){
            _controller.AimHasChanged = false;
        }
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
    /**
     * Effet graphique permettant à l'utilisateur de voir quelle case est survolée. 
     * Eclaircit la couleur de base de la case
     * */
    private Color GetHoverColor()
    {
        float r, g, b, a;

        r = (float)startColor.r * 2;
        g = (float)startColor.g * 2;
        b = (float)startColor.b * 2;

        return new Color(r, g, b, startColor.a);
    }
    void CreatePoints(float range)
    {
        float x;
        float y;
        float z;
        int segments = 50;
        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * (range/2);
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * (range/2);

            _lineR.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }

    public void OnMouseEnter()
    {
        _lineR.enabled = true;
        //rend.material.color = hoverColor;
    }

    public void OnMouseExit()
    {
        _lineR.enabled = false;
        //rend.material.color = startColor;
    }

    public void OnMouseDown()
    {
        //BuildTurret();
        Debug.Log("Turret Action");
        //_controller.Upgrade();
    }

    public void Die()
    {
        Destroy(_instance);
    }

    public void UpdateRange(){
        CreatePoints(_controller.GetRange());
    }
    public void ShootUI(){
        _sound.Play();
    }
}
