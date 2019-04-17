using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBladeController : MonoBehaviour
{
    [SerializeField]GameObject blade;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward,2);
    }

    public int getDamage()
    {
        return 10;
    }
}
