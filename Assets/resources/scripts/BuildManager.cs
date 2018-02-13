using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Pour l'instant cette classe ne renvoit que qu'un seul TurretModel à bâtir
 * mais son fonctionnement est amené à se complexifier dans les prochains sprints
 * */
public class BuildManager : MonoBehaviour {

    private TurretModel _turretToBuild;
    private static BuildManager _instance;
    private static bool _isWaiting = false;

    public bool IsWaiting{
        get{return _isWaiting;}    
    }

    public void Awake() {
        if(_instance == null) {
            _instance = this;
        }

        
    }
    public TurretModel GetTurretToBuild() {

        TurretModel building = _turretToBuild;
        _turretToBuild = null;
        _isWaiting = false;

        return building;
    }

    public static BuildManager GetInstance() {
        return _instance; 
    }

    public void SetTurretToBuild(TurretModel model) {
        _turretToBuild = model;
        _isWaiting = true;
    }
}
