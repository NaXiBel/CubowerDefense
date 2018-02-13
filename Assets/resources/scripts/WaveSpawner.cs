using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

    private static GameObject _wavePrefab;
    private static Transform _spawnPoint;
    private static float _timeBetweenWaves = 5f;
    private static float _countdown = 2f;
    private static Wave _currentWave;
    private static IWaveSelector _waveSelector;


    public static Transform GetSpawnPoint() {
        return _spawnPoint;
    }

    private void Awake() {

        _wavePrefab = ((GameObject)Resources.Load("prefabs/Wave", typeof(GameObject)));
        _spawnPoint = GameObject.Find("START").transform;


    }
    
    public static Wave CurrentWave {
        get { return _currentWave; }
    }
    /**
     * Time.deltatime est le temps passé depuis la dernière frame.
     * countdown -= Time.deltaTime revient à dire : "Décrémenter de 1 
     * toutes les secondes".
     * 
     * Dès le démarrage, la vague apparaîtra après environ [countdown - val initiale] secondes,
     * elle se renouvellera toutes les [timeBetweenWaves] secondes.
     * */
    void Update() {
        if (!GameController.GameOver)
        {
            //_waveSelector = new WaveType1(GameData.WaveIndex);
            _waveSelector = new WaveType2(GameData.WaveIndex);
            if (_currentWave == null)
            {
                SpawnWave();
            }
            else if (_currentWave.isFinished() && _countdown <= 0f)
            {
                _currentWave.Die();
                _countdown = _timeBetweenWaves;
            }

            _countdown -= Time.deltaTime;
        }
        
    }

   
    private static void SpawnWave() {

        GameData.WaveIndex++;
        GameObject instance = Instantiate(_wavePrefab, _spawnPoint.position, _spawnPoint.rotation);
       
        _currentWave = instance.GetComponent<Wave>();
        _currentWave.Instance = instance;
        _currentWave.InitializeWave(_waveSelector.GetWaveComponents()); 
        

    }

    public static void EndWave()
    {
        _currentWave.Die();
    }

    public static void ResetData(){
        
    }

}
