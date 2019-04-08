using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarGUI : MonoBehaviour
{
    [SerializeField] FloatVariable currentHealth;
    [SerializeField] RectTransform healthBar;
    
    void Start()
    {
        healthBar.localScale = new Vector3(0, 1, 1);
    }


    public void UpdateHpBar()
    {
        healthBar.localScale = new Vector3(currentHealth.Value, 1, 1);
    }


}
