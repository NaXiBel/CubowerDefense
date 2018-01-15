using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private Color startColor; 
    private Color hoverColor;

    private TurretController turret;
    private Renderer rend;

    /**
     * Effet graphique permettant à l'utilisateur de voir quelle case est survolée. 
     * Eclaircit la couleur de base de la case
     * */
    private Color GetHoverColor() {
        float r, g, b, a;

        r = (float)startColor.r * 2;
        g = (float)startColor.g * 2;
        b = (float)startColor.b * 2;

        return new Color(r, g, b, startColor.a);
    }

    public void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        hoverColor = GetHoverColor(); 

    }

    public void OnMouseDown() {
        BuildTurret();
    }

    /** 
     * Une tourelle est fixée à une case
     * */
    private void BuildTurret() {

        if (turret != null) {
            Debug.Log("Can't build there !");
            return;
        }

        Vector3 spawnPosition = new Vector3(transform.position.x, 0.7f, transform.position.z);
        TurretModel turretToBuild = BuildManager.GetInstance().GetTurretToBuild();
        TurretController turretBuilt = new TurretController(turretToBuild, spawnPosition, this.transform);

        turret = turretBuilt;

    }

    public void OnMouseEnter() {
        rend.material.color = hoverColor;     
    }

    public void OnMouseExit() {
        rend.material.color = startColor; 
    }
}
