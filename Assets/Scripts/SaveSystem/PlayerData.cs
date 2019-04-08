using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "BulletBehaviour", menuName = "SaveDataObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject, ISaveData,ILoadData
{
    public static PlayerData _PlayerData;

    [SerializeField] int HealthLevel;
    [SerializeField] int FireRateLevel;
    [SerializeField] int BulletDamageLevel;
    [SerializeField] int BulletNumLevel;
    [SerializeField] int AttractorLevel;
    [SerializeField] int Sp;


    [Button(Name = "LoadData")]
    public void Load()
    {
        if (ES3.FileExists("SaveData"))
        {
            if (ES3.KeyExists("PlayerData", "SaveData"))
            {

                ES3.LoadInto<PlayerData>("PlayerData", "SaveData", this);

                Debug.Log("PlayerDataLoaded " +
                     ", HealthLevel: " + HealthLevel +
                     ", FireRateLevel: " + FireRateLevel +
                     ", BulletDamageLevel:" + BulletDamageLevel +
                     ", BulletNumLevel: " + BulletNumLevel +
                     ", AttractorLevel: " + AttractorLevel +
                     ", Sp: " + Sp);
            }

        }
        else
        {
            HealthLevel = 1;
            FireRateLevel = 1;
            BulletDamageLevel = 1;
            BulletNumLevel = 1;
            AttractorLevel = 1;
            Sp = 0;
            ES3.Save<PlayerData>("PlayerData", this, "SaveData");
            Debug.Log("SaveData File Not found, PlayerData key created and loaded default values");
        }
    }

    [Button(Name = "Save")]
    public void Save()
    {
        ES3.Save<PlayerData>("PlayerData", this, "SaveData");
        Debug.Log("PlayerDataSaved "+ ", HealthLevel: " + HealthLevel + ", FireRateLevel: " + FireRateLevel + ", BulletDamageLevel:" + BulletDamageLevel + ", BulletNumLevel: " + BulletNumLevel + ", AttractorLevel: " + AttractorLevel + ", Sp: " + Sp);
    }

    public string getSP()
    {
        return Sp.ToString();
    }

    private void OnEnable()
    {
        _PlayerData = this;        
    }

}
