using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerHealthConfig healthConfig;
    [SerializeField] float deathTime;
    [SerializeField] UnityEvent DamageEvent;
    [SerializeField] UnityEvent DeathEvent;
    
    void Start()
    {
        healthConfig.ResetHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Bullet>())
        {
            collision.gameObject.GetComponent<Bullet>().Hit();
            healthConfig.ApplyChange(-1);
            DamageEvent.Invoke();
        }


        if (healthConfig.Health <= 0.0f)
        {
            DeathEvent.Invoke();
        }

    }

    public void StartDeath()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        
        gameObject.SetActive(false);
    }

    [Button]
    void DamagePlayer()
    {
        healthConfig.ApplyChange(-1);
        DamageEvent.Invoke();

        if (healthConfig.Health <= 0.0f)
        {
            DeathEvent.Invoke();
        }
    }
}
