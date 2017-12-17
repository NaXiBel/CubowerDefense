using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private Color startColor; 
    private Color hoverColor;

    // à changer pour le projet
    private Turret turret;
    private Renderer rend;

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
        
        if(turret != null) {
            Debug.Log("Can't build there !");
            return; 
        }

        Vector3 spawnPosition = new Vector3(transform.position.x, 0.7f, transform.position.z);
        GameObject turretToBuild = BuildManager.GetInstance().GetTurretToBuild();
        GameObject turretBuilt = Instantiate(turretToBuild, spawnPosition, transform.rotation);

        turret = turretBuilt.GetComponent<Turret>(); 

    }

    public void OnMouseEnter() {
        rend.material.color = hoverColor;     
    }

    public void OnMouseExit() {
        rend.material.color = startColor; 
    }
}
