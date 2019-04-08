using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;


public class LevelCreator : Editor
{
    Level level;
    


    private void OnEnable()
    {
        level = (Level)target;
        
    }

    [MenuItem("CONTEXT/Level/setupLevel")]
    static void SetupLevel(MenuCommand command)
    {

        LevelSaveData Save = CreateInstance<LevelSaveData>();
        Save.name = command.context.name + "_save";
        Save.Level_ID = command.context.name;
        LevelData data = CreateInstance<LevelData>();
        data.name = command.context.name + "_data";
        data.Level_ID = command.context.name;
        LevelScript Script = CreateInstance<LevelScript>();
        Script.name = command.context.name + "_script";


        

        AssetDatabase.AddObjectToAsset(Save, AssetDatabase.GetAssetPath(command.context));
        AssetDatabase.AddObjectToAsset(data, AssetDatabase.GetAssetPath(command.context));
        AssetDatabase.AddObjectToAsset(Script, AssetDatabase.GetAssetPath(command.context));
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(command.context));

        Debug.Log("LevelHasBeenSetUp");
    }
}
