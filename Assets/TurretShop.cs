using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretShop : MonoBehaviour {

    private BuildManager _buildManager;
    private static Node _selectedNode = null;
    private static GameObject _priority;
    private static Text _priorityTxt;
    private static GameObject _upgrade;
    private static GameObject _sell;
    private static Text _upgradePrice;
    private static Text _sellPrice;
    private static Text _lightPrice;
    private static Text _standardPrice;
    private static Text _heavyPrice;
    private static Color _startColor;
    private Color _hoverColor;
    private static Color _errorColor;

    public static Node SelectedNode {
        set{
            _selectedNode = value;
            TurretShopUI(true);
        }
    }

    void Start() {
        _buildManager = BuildManager.GetInstance();
        _upgradePrice = GameObject.Find("UpgradePrice").GetComponent<Text>();
        _sellPrice = GameObject.Find("SellPrice").GetComponent<Text>();
        _lightPrice = GameObject.Find("LightPrice").GetComponent<Text>();
        _standardPrice = GameObject.Find("StandardPrice").GetComponent<Text>();
        _heavyPrice = GameObject.Find("HeavyPrice").GetComponent<Text>();
        _upgrade = GameObject.Find("Upgrade");
        GameObject.Find("Upgrade").SetActive(false);
        _sell = GameObject.Find("Sell");
        GameObject.Find("Sell").SetActive(false);
        _priorityTxt = GameObject.Find("PriorityTxt").GetComponent<Text>();
        _priority = GameObject.Find("Priority");
        GameObject.Find("Priority").SetActive(false);
        _startColor = _sell.GetComponent<Image>().color;
        _hoverColor = Utils.GetHoverColor(_startColor);
        _errorColor = Utils.GetErrorColor(_startColor);

        _lightPrice.text = "$" + new LightTurret().Price;
        _standardPrice.text = "$" + new StandardTurret().Price;
        _heavyPrice.text = "$" + new HeavyTurret().Price;


    }

    public void SelectLightTurret() {
        _buildManager.SetTurretToBuild(new LightTurret());
    }

    public void SelectStandardTurret() {
        _buildManager.SetTurretToBuild(new StandardTurret());

    }

    public void SelectHeavyTurret() {
        _buildManager.SetTurretToBuild(new HeavyTurret());
    }

    public void UpgradeTurret()
    {
        if (_selectedNode.Turret.Upgrade() != -1){
            _upgrade.GetComponent<Image>().color = _startColor;
            Debug.Log("Upgrade");
            _upgradePrice.text = "$" + _selectedNode.Turret.GetUpgradePrice();
            _sellPrice.text = "$" + _selectedNode.Turret.GetSellPrice();
        }
        else{
            //graphic
            _upgrade.GetComponent<Image>().color = _errorColor;
        }
        
        
    }

    public void SellTurret()
    {
        _selectedNode.Turret.Sell();
        Debug.Log("Sell");
        _selectedNode.Turret = null;
        _selectedNode = null;
        TurretShopUI(false);
    }

    public void ChangePriority()
    {
        List<IAimPriority> priorityList = new List<IAimPriority>();
        priorityList.Add(new NearestPriority());
        priorityList.Add(new WeakPriority());
        priorityList.Add(new StrongPriority());
        priorityList.Add(new RandPriority());

        string id = _selectedNode.Turret.AimType.GetInitials();
        bool found = false;
        int index = 0;
        for(int i = 0;!found && i<priorityList.Count;++i){
            if (priorityList[i].GetInitials() == id){
                index = (i + 1) % (priorityList.Count);
                _selectedNode.Turret.AimType = priorityList[index];
                found = true;
            }
        }
        if (found) TurretShopUI(true);
    }

    public static void TurretShopUI(bool b){
        if (b){
            _upgrade.GetComponent<Image>().color = _startColor;
            _upgrade.SetActive(true);
            _sell.SetActive(true);
            _priority.SetActive(true);
            _priorityTxt.text = _selectedNode.Turret.AimType.GetInitials();
            _upgradePrice.text = "$" + _selectedNode.Turret.GetUpgradePrice();
            _sellPrice.text = "$"+ _selectedNode.Turret.GetSellPrice();
        }
        else{
            _upgrade.GetComponent<Image>().color = _startColor;
            _upgrade.SetActive(false);
            _sell.SetActive(false);
            _priority.SetActive(false);
        }
    }
    public static void ResetData(){
        _selectedNode = null;
        TurretShopUI(false);
    }

}
