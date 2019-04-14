using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerWeaponList", menuName = "Player/PlayerWeaponList")]
public class PlayerWeaponList : ScriptableObject
{
    public static PlayerWeaponList _List;
    [SerializeField]public List<WeaponType> Types;
    private void OnEnable()
    {
        _List = this;
    }
}
