using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShredder : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collider)
    {

        collider.GetComponent<Bullet>().Hit();
    }
}
