using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class WaveType1 : IWaveSelector {
    private int _waveIndex;

    public int WaveIndex {
        get { return _waveIndex; }
    }
    public WaveType1(int waveIndex) {
        _waveIndex = waveIndex;
    }

    public List<EnemyModel> GetWaveComponents() {
        int size = _waveIndex + 5;

        List<EnemyModel> models = new List<EnemyModel>();

        for(int i = 0 ; i < size ; ++i) {
            models.Add(new StandardEnemy());

            if(i % 4 == 0) {
                models.Add(new HeavyEnemy());
            }

            if (i % 2 == 0) {
                models.Add(new LightEnemy());
            }
        }

        return models;
    }
}