using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float speed;
    [SerializeField] public int score;
}
