using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController {

    public static TurretController _selectedTurret;
    public static bool _gameOver = false;
    public static bool _restart = true;
    public static List<Node> _map = new List<Node>();

    public static void Notify () {
        if (GameData.PlayerHealth <= 0) {
            EndGame();
        }

    }
    public static void HealthDown() {
        if(GameData.PlayerHealth - 1 <= 0)EndGame();
        else GameData.PlayerHealth--;
    }

    private static void EndGame() {
        Debug.Log("Game Ended");
        _gameOver = true;
        WaveSpawner.EndWave();
    }

    public static TurretController SelectedTurret {
        get { return _selectedTurret; }
        set { _selectedTurret = value; }
    }

    public static bool GameOver
    {
        get{ return _gameOver; }
    }

    public static bool Restart {
        get { return _restart; }
        set { _restart = value; }
    }

    public static bool HasEnough(int price)
    {
        return (GameData.Money - price) > -1;
    }

    public static void GainMoney(int gains) {
        GameData.Money = GameData.Money + gains;
    }

    //returns -1 when not enough, 0 otherwise
    public static int Pay(int price)
    {
        if (HasEnough(price))
        {
            GameData.Money = GameData.Money - price;
            return 0;
        }
        else
        {
            return -1;
        }
        
    }

    public static void StartGame(){
        _selectedTurret = null;
        _gameOver = false;
    }

    public static void RestartGame(){
        StartGame();
        GameData.ResetData();
        TurretShop.ResetData();
        foreach (Node n in _map) n.Turret = null;
    }


}
