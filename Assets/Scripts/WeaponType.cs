using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponType : ScriptableObject
{
    [SerializeField] PlayerBulletBehaviour BulletBehaviour;
    [SerializeField] public Sprite WeaponSprite;
}
