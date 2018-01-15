using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class WaveType1 : IWaveSelector {
    private int _waveIndex;

    public int WaveIndex {
        get { return _waveIndex; }
    }
    public WaveType1(int waveIndex) {

    }

    public Dictionary<GameObject, int> GetWaveComponents() {
        return null;
    }
}