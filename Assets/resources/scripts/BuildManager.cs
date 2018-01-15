using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Pour l'instant cette classe ne renvoit que qu'un seul TurretModel à bâtir
 * mais son fonctionnement est amené à se complexifier dans les prochains sprints
 * */
public class BuildManager : MonoBehaviour {

    private TurretModel turretToBuild;
    private static BuildManager instance;

    public void Awake() {
        if(instance == null) {
            instance = this;
        }

        turretToBuild = new StandardTurret();
    }
    public TurretModel GetTurretToBuild() {
        return turretToBuild;
    }

    public static BuildManager GetInstance() {
        return instance; 
    }
}
