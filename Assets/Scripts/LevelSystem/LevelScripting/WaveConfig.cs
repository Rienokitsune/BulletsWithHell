using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveConfig : ScriptableObject
{   
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int NumOfEnemies;
    [SerializeField] PathAsset path;
    [SerializeField] float spawnInterval;
    [SerializeField] float speed;
    

    public GameObject GetEnemy(){ return enemyPrefab; }

    public PathAsset GetPath() { return path; }

    public int GetNumOfEnemies() { return NumOfEnemies; }

    public float GetSpawnInterval() { return spawnInterval; }

    public float GetSpeed() { return speed; }

    public Vector3 GetStartPos() { return path.points.waypoints[0]; }



}
