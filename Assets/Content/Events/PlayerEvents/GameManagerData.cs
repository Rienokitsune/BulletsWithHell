using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class GameManagerData : ScriptableObject, ISaveData
{
    public static GameManagerData _GameManagerData;
    public Level level;
    public float timer;
    public int score;
    public float multiplier;
    public int kills;
    public int enemiesSpawned;
    public int itemsSpawned;
    public int itemsCollected;

    private void OnEnable()
    {
        _GameManagerData = this;
        score = 0;
        kills = 0;
        enemiesSpawned = 0;
        itemsSpawned = 0;
        itemsCollected = 0;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void Save()
    {
        
    }

    public void Reset()
    {
        timer = 0;
        multiplier = 0;
        score = 0;
        kills = 0;
        enemiesSpawned = 0;
        itemsSpawned = 0;
        itemsCollected = 0;
    }

    public float GetMultiplier() { return multiplier; }
    public int GetDestruction() { return Mathf.FloorToInt((kills / enemiesSpawned) * 100); }
    public string GetTime() { string formattedTime = string.Format("{0:00}'{1:00}", Mathf.Floor(timer % 60), Mathf.Floor((timer * 100) % 60)); return formattedTime; }

#if UNITY_EDITOR
    [Button]
void add1000Score()
    {
        score += 1000;
    } 
#endif

}
