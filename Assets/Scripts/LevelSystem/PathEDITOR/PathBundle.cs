using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// Scriptable object holding groups of paths.


[CreateAssetMenu(fileName = "NewPathBundle", menuName = "LevelCreator/PathBundle", order = 1)]
public class PathBundle : ScriptableObject
{

    [AssetList(CustomFilterMethod ="HasPrefix")]

    [SerializeField] public List<PathAsset> paths;

    private bool HasPrefix(PathAsset obj)
    {
        return obj.name.Contains(this.name);
    }

    public List<PathAsset> GetPaths()
    {
        return paths;
    }
}
