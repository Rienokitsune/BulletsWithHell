using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BladeConfig : ScriptableObject
{
    [SerializeField] int[] damageAtLevel;
    [SerializeField] [Range(0, 1)] public float[] RotationSpeedAtLevel;
}
