using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    private float panSpeed = 30f;
    private float panBorderThickness = 10f;
    private float scrollSpeed = 5f;
    private bool doMovement = true;
    private float minY = 15f;
    private float maxY = 80f; 

    /**
     * multiplication par Time.deltaTime pour que le déplacement soit indépendant
     * vis à vis du frame rate
     * */
    void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) {
            doMovement = !doMovement;
        }

        if(!doMovement) {
            return;
        }

        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBorderThickness ) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q") || Input.mousePosition.x <= panBorderThickness) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000* scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); 
        transform.position = pos;
    }
}
