using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "playerData", menuName = "SaveDataObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject, ISaveData,ILoadData
{
    public static PlayerData _PlayerData;

    [System.Serializable]
    public class PlayerUpgradeData
    {
        [SerializeField]public UpgradeTypes.UpgradeType type;
        [SerializeField] int level;

        public int GetLevel()
        {
            return level;
        }
        public void LoadDefault()
        {
            level = 1;
        }
        public void levelUP()
        {
            level += 1;
        }
    }
    [System.Serializable]
    public class WeaponSlotData
    {
        public int slotID;
        [SerializeField] public GameObject WeaponPrefab;

        public void SetWeaponSlot(GameObject Weapon)
        {
            WeaponPrefab = Weapon;
        }
    }

    [SerializeField]public PlayerUpgradeData[] playerUpgrades;
    [SerializeField] int Sp;

    public int GetLevel(UpgradeTypes.UpgradeType type)
    {
        foreach (PlayerUpgradeData data in playerUpgrades)
        {
            if(data.type == type)
            {
                return data.GetLevel();
            }
        }

        return 0;
    }

    [Button(Name = "LoadData")]
    public void Load()
    {
        if (ES3.FileExists("SaveData"))
        {
            if (ES3.KeyExists("PlayerData", "SaveData"))
            {

                ES3.LoadInto<PlayerData>("PlayerData", "SaveData", this);

                Debug.Log(" Sp:"  + Sp);
            }

        }
        else
        {
            foreach (PlayerUpgradeData data in playerUpgrades)
            {
                data.LoadDefault();
            }
            Sp = 0;
            ES3.Save<PlayerData>("PlayerData", this, "SaveData");
            Debug.Log("SaveData File Not found, PlayerData key created and loaded default values");
        }
    }

    [Button(Name = "Save")]
    public void Save()
    {
        ES3.Save<PlayerData>("PlayerData", this, "SaveData");
        foreach (PlayerUpgradeData data in playerUpgrades)
        {
            Debug.Log("saved: " + data.GetLevel());
        }
    }

    public int getSP()
    {
        return Sp;
    }

    public void SubtractSP(int cost)
    {
        Sp -= cost;
    }

    private void OnEnable()
    {
        _PlayerData = this;        
    }

    [Button]
    void Add1000Sp()
    {
        Sp += 1000;
    }

}
