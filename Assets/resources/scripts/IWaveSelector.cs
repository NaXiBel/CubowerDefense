using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public interface IWaveSelector {
    int WaveIndex {
        get;
    }
    Dictionary<GameObject,int> GetWaveComponents();

}