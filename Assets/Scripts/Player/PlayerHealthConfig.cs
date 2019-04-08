using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerHealthConfig", menuName = "Player/PlayerHealthConfig")]
public class PlayerHealthConfig : ScriptableObject
{
    [SerializeField]public int MaxHealth;
     public int Health;

    private void OnEnable()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        Health = MaxHealth;
    }

    public void ApplyChange(int a)
    {
        Health += a;
    }
}
