using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "MainScene";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {
        Debug.Log("Play");
        GameController.StartGame();
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
