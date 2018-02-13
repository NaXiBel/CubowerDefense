using UnityEngine;
using System.Collections;
using System;

class TurretFactory : MonoBehaviour {
    public static TurretView InstantiateView(Vector3 startPoint, Transform node, string prefabName, TurretController tc) {
        GameObject prefab = ((GameObject)Resources.Load("prefabs/" + prefabName, typeof(GameObject)));
        GameObject view = Instantiate(prefab, startPoint, node.transform.rotation);

        TurretView turretView = view.GetComponent<TurretView>();
        Debug.Log(view);
        turretView.Controller = tc;
        turretView.Instance = view;

        return turretView;
    }

}