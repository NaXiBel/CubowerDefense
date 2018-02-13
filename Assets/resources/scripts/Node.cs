using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private Color startColor; 
    private Color hoverColor;
    private Color errorColor;

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
        GameController._map.Add(this);
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        hoverColor = GetHoverColor();
        errorColor = Utils.GetErrorColor(startColor);

    }

    public void OnMouseDown() {
        if (turret != null) TurretShop.SelectedNode = this;
        else if(turret==null && BuildManager.GetInstance().IsWaiting){
            BuildTurret();
        }
        else{
            TurretShop.TurretShopUI(false);
        }
    }

    /** 
     * Une tourelle est fixée à une case
     * */
    private void BuildTurret() {
        TurretModel turretToBuild = BuildManager.GetInstance().GetTurretToBuild();
        if (turret != null) {
            Debug.Log("Can't build there !");
            return;
        }else if (GameController.Pay(turretToBuild.Price) != -1){
            Vector3 spawnPosition = new Vector3(transform.position.x, 0.7f, transform.position.z);

            Debug.Log("Turret to build : " + turretToBuild);
            TurretController turretBuilt = new TurretController(turretToBuild, spawnPosition, this.transform);

            turret = turretBuilt;
        }else{
            //Not enough money
            Debug.Log("Not enough money");
            rend.material.color = errorColor;
        }

        

    }

    public void OnMouseEnter() {
        if(turret != null)
        {
            turret.View.OnMouseEnter();
        }
        rend.material.color = hoverColor;     
    }

    public void OnMouseExit() {
        if (turret != null)
        {
            turret.View.OnMouseExit();
        }
        rend.material.color = startColor;
    }

    public TurretController Turret {
        get{ return turret; }
        set{ turret = value; }
    }
}
