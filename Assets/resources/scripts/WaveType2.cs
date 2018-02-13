using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class WaveType2 : IWaveSelector {
    private int _waveIndex;

    public int WaveIndex {
        get { return _waveIndex; }
    }
    public WaveType2(int waveIndex) {
        _waveIndex = waveIndex;
    }

    public List<EnemyModel> GetWaveComponents() {
        int size = _waveIndex + 2;

        List<EnemyModel> models = new List<EnemyModel>();
        float pHE, pLE, pSE;

        pSE = 0.5f;
        pLE = 0.25f;
        pHE = 0.125f;
        float rand = Random.Range(0f, 1f);
        Debug.Log("Rand = " + rand);
        Debug.Log("PSE = " + pSE);
        for (int i = 0 ; i < size ; ++i) {
            rand = Random.Range(0f, 1f);
            Debug.Log("Rand = " + rand);
            if (rand<pSE) {
                models.Add(new StandardEnemy());
                pSE = pSE - 0.1f;
                pLE += 0.06f;
                pHE += 0.04f;
            }else if (rand<pSE+pLE) {
                models.Add(new LightEnemy());
                pLE = pLE - 0.12f;
                pSE += 0.08f;
                pHE += 0.04f;
            }
            else{
                models.Add(new HeavyEnemy());
                pHE = pHE - 0.1f;
                pSE += 0.07f;
                pLE += 0.03f;
            }
        }

        return models;
    }
}