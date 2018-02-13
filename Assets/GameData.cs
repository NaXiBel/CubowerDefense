using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {


    private const int _initialMoney = 360;
    private const int _initialHealth = 20;
    private static int _playerHealth = _initialHealth;
    private static int _waveIndex = 0;
    private static int _money = _initialMoney;


    public static int PlayerHealth {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    public static int WaveIndex {
        get { return _waveIndex; }
        set { _waveIndex = value; }
    }

    public static int Money {
        get { return _money; }
        set { _money = value; }
    }

    public static void ResetData(){
        _money = _initialMoney;
        _playerHealth = _initialHealth;
        _waveIndex = 0;
    }
    
}
