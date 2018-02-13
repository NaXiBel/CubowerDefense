using UnityEngine;
using System.Collections;
using System;

public class EnemyFactory : MonoBehaviour {

    /**
     * Permet de retourner une instance de la vue vers le controleur.
     * Le modèle 3D de l'ennemi est instancié sur la map à cet instant
     * */
    public static EnemyView InstantiateView(Transform startPoint, string prefabName,EnemyController ec) {
        GameObject prefab = ((GameObject)Resources.Load("prefabs/"+prefabName, typeof(GameObject)));
        GameObject view = Instantiate(prefab, startPoint.position, startPoint.rotation);
        
        EnemyView enemyView = view.GetComponent<EnemyView>();
        enemyView.Instance = view;
        enemyView.Controller = ec;
        return enemyView;
    }
}
