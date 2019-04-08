using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "SaveSystem", menuName = "SaveDataObjects/SaveSystem", order = 1)]
public class SaveSystem : ScriptableObject
{
    public static SaveSystem _SaveSystem;
    [SerializeField]List<ScriptableObject> saveables;

    [Header("LevelList")][AssetList][SerializeField] List<LevelSaveData> LevelSaves;

    private void OnEnable()
    {
        _SaveSystem = this;
        LoadAll();
    }

    public void AddLevelSave(LevelSaveData obj)
    {
        LevelSaves.Add(obj);
    }

    [Button]
    public void SaveAll()
    {
        foreach(ISaveData obj in saveables)
        { 
            obj.Save();
        }

        foreach (LevelSaveData save in LevelSaves)
        {
            save.Save();
        }

    }

    [Button]
    public void LoadAll()
    {
        foreach(ILoadData obj in saveables)
        {
            obj.Load();
        }

        foreach (LevelSaveData save in LevelSaves)
        {
            save.Load();
        }
    }

    [Button(Name = "ClearSave")]
    public void ClearData()
    {
        Debug.Log("Cleared SaveData");
        ES3.DeleteFile("SaveData");
    }
}
