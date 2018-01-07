using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

    private static GameObject _enemyPrefab;
    private static GameObject _wavePrefab;
    private static Transform _spawnPoint;
    private static float _timeBetweenWaves = 5f;
    private static float _countdown = 2f;
    private static int _waveIndex = 0;
    private static Wave _currentWave;


    public static Transform GetSpawnPoint() {
        return _spawnPoint;
    }

    private void Awake() {

        _enemyPrefab = ((GameObject)Resources.Load("prefabs/Enemy", typeof(GameObject)));
        _wavePrefab = ((GameObject)Resources.Load("prefabs/Wave", typeof(GameObject)));
        _spawnPoint = GameObject.Find("START").transform;



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

        if (_currentWave == null) {
            SpawnWave();
        } else if (_currentWave.isFinished() && _countdown <= 0f) {
            ++_waveIndex;
            Destroy(_currentWave);
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

    }


    private static void SpawnWave() {

        _waveIndex++;
        Dictionary<GameObject, int> waveComponents = new Dictionary<GameObject, int>();
        waveComponents.Add(_enemyPrefab, 10);


        Wave wave = Instantiate(_wavePrefab, _spawnPoint.position, _spawnPoint.rotation).GetComponent<Wave>();
        _currentWave = wave;
        wave.InitializeWave(waveComponents);

    }

}
