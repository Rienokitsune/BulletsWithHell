using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpGUI : MonoBehaviour
{

    [SerializeField] PlayerData data;
    [SerializeField] Text text;

    IEnumerator Start()
    {
        while (true)
        {
            text.text = data.getSP().ToString();
            yield return new WaitForSeconds(0.5f);        
        }
        
    }

    
}
