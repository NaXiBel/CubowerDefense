using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {


    private static Text _waveIndex;
    private static Text _coins;
    private static Text _pv;
    private static GameObject _gameOverPanel;
    private static Text _finalScore;
    private static string _menuToLoad = "MainMenu";
    private static AudioSource _sound;

    void Start () {
        _sound = GameObject.Find("GameMaster").GetComponent<AudioSource>();
        _waveIndex = GameObject.Find("WaveIndex").GetComponent<Text>();
        _waveIndex.text = GameData.WaveIndex.ToString();
        _coins = GameObject.Find("Money").GetComponent<Text>();
        _coins.text = '$'+GameData.Money.ToString();
        _pv = GameObject.Find("PV").GetComponent<Text>();
        _pv.text = GameData.PlayerHealth.ToString();
        _finalScore = GameObject.Find("FinalWaveCount").GetComponent<Text>();

        _gameOverPanel = GameObject.Find("GameOver");
        _gameOverPanel.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameController.GameOver)
        {
            _waveIndex.text = GameData.WaveIndex.ToString();
            _coins.text = '$' + GameData.Money.ToString();
            _pv.text = GameData.PlayerHealth.ToString();
        }
        else{
            _sound.Stop();
            Debug.Log("Dans update = " + GameData.WaveIndex.ToString());
            _finalScore.text = GameData.WaveIndex.ToString();
            _gameOverPanel.SetActive(true);
            
            
        }

    }

    public void onRetryButtonMouseDown(){
        //Call gamecontroller to reset game.
        Debug.Log("Reset game");
        GameController.RestartGame();
        _gameOverPanel.SetActive(false);
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Turret");
        for (int i = 0;i<clones.Length ;++i){
            Destroy(clones[i].gameObject);
        }
        _sound.Play();
    }

    public void onExitButtonMouseDown(){
        //return to mainmenu
        Debug.Log("return to mainmenu");
        SceneManager.LoadScene(_menuToLoad);
    }
    
}
