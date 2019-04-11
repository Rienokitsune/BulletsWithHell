using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponType : ScriptableObject
{
    [SerializeField] public GameObject WeaponPrefab;
    [SerializeField] public Sprite WeaponSprite;
}
