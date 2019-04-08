using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : ScriptableObject
{
   [SerializeField] List<WaveConfig> configs;
   [SerializeField] List<float> timestamps;

    public List<WaveConfig> GetWaveConfigs() { return configs; }
    public List<float> GetTimestamps() { return timestamps;  }
}
