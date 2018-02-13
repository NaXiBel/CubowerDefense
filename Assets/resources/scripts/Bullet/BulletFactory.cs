using UnityEngine;
using System.Collections;

public class BulletFactory : MonoBehaviour {

    public static BulletView InstantiateView(Transform startPoint, string prefabName, BulletController bc) {
        GameObject prefab = ((GameObject)Resources.Load("prefabs/" + prefabName, typeof(GameObject)));
        GameObject view = Instantiate(prefab, startPoint.position, startPoint.rotation);

        BulletView bulletView = view.GetComponent<BulletView>();
        bulletView.Controller = bc;
        bulletView.Instance = view;
        return bulletView;
    }
}
