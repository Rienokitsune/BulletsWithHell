using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelSaveData : ScriptableObject, ISaveData, ILoadData
{
 
    public string Level_ID;
    [SerializeField] int topScore;
    [SerializeField] float topTime;
    [SerializeField] bool[] goalChecks;


    [Button]
    public void Load()
    {
        if (ES3.FileExists("SaveData"))
        {
            if (ES3.KeyExists(Level_ID + "_save","SaveData"))
            {
                ES3.LoadInto(Level_ID+"_save", "SaveData",this);
                Debug.Log("Loaded " + this.name );
            }else
            {
                InitializeDefaultValues();
                ES3.Save<LevelSaveData>(Level_ID + "_save", this, "SaveData");
                Debug.Log("Initialized " + this.name +" with default values");                
            }

        }
        
    }


    [Button]
    public void Save()
    {
        if (ES3.FileExists("SaveData"))
        {
            if (ES3.KeyExists(Level_ID + "_save", "SaveData"))
            {
                ES3.Save<LevelSaveData>(Level_ID + "_save", this, "SaveData");

                Debug.Log("Saved " + this.name);
            }
            else
            {
                InitializeDefaultValues();
                ES3.Save<LevelSaveData>(Level_ID + "_save", this, "SaveData");
                Debug.Log("Initialized and saved " + this.name + " with default values");
            }

        }
        
    }

    public void InitializeDefaultValues()
    {
        topScore = 0;
        topTime = 0;
        goalChecks = new bool[5] { false, false, false, false, false };
    }

    public int GetTopScore()
    {
        return topScore;
    }

    public float GetTopTime()
    {
        return topTime;
    }


}
