using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthGUI : MonoBehaviour
{

    [SerializeField]public PlayerHealthConfig healthConfig;
    [SerializeField]public GameObject[] healthIcon;

   public void RemoveHealth()
    {
        healthIcon[healthConfig.Health].SetActive(false);
    }

   public void ResetHealth()
    {
        foreach(GameObject hp in healthIcon)
        {
            hp.SetActive(true);
        }
    }
}
