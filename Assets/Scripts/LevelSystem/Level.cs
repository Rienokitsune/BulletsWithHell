using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level" ,menuName = "LevelCreator/Level File", order = 1)]
public class Level : ScriptableObject
{
    public static Level _currentLevel;
  [SerializeField] string Level_ID;
   [SerializeField] LevelScript script;   
   [SerializeField] LevelData data;
   [SerializeField] LevelSaveData saveData;


    private void OnEnable()
    {
        Level_ID = this.name;
    }

    public LevelScript GetLevelScript() { return script; }
    public LevelData GetLevelData() { return data; }
    public LevelSaveData GetLevelSaveData() { return saveData; }

    public void SetCurrentLevel()
    {
        _currentLevel = this;
    }

}
