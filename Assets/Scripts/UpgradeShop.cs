using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class UpgradeShop : ScriptableObject, ILoadData
{

    [SerializeField]UnityEvent UpgradeBought;
    [SerializeField]UnityEvent UpgradeDenied;

    [System.Serializable]
    public class Upgrade
    {
        public int currentLevel;
        public int maxLevel;
        public UpgradeTypes.UpgradeType upgradeType;
        public int[] cost;

        public void LoadCurrentLevel(PlayerData levels)
        {
            currentLevel = levels.GetLevel(upgradeType);
        }
    }

    [SerializeField] public PlayerData data;
    [SerializeField] public Upgrade[] upgrades;

    private void OnEnable()
    {
        Load();
    }

    public void BuyUpgrade(UpgradeTypes.UpgradeType upgradeType , int cost)
    {
        foreach(PlayerData.PlayerUpgradeData upgrade in data.playerUpgrades)
        {
            if(upgradeType == upgrade.type)
            {
                if(cost > data.getSP())
                {
                    UpgradeDenied.Invoke();
                }
                else
                {
                    UpgradeBought.Invoke();
                    upgrade.levelUP();
                    Load();
                    data.SubtractSP(cost);
                }
                

            }
        }
    }

    [Button]
    public void Load()
    {
        foreach  (Upgrade config in upgrades)
        {
            config.LoadCurrentLevel(data);
        }
        
    }

    
}
