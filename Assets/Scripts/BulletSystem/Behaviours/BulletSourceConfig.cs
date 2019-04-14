using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BulletSourceConfig : ScriptableObject
{
    [SerializeField] public string Pool_ID;
    [SerializeField] public AnimationCurve BulletSpeed;
    [SerializeField] public AnimationCurve NumOfBullets;
    [SerializeField] public AnimationCurve ShotDelay;
    [SerializeField] public AnimationCurve RotationSpeed;
    [SerializeField] [Range(0, 360)]public int coneAngle;
    [SerializeField] public float offsetZ;
}
