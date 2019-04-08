using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[RequireComponent(typeof(PathMoverSimple))]
public class Enemy : MonoBehaviour {

    [SerializeField][AssetList] EnemyConfig config;
    [SerializeField] FloatVariable currentGUIhp;
    [SerializeField] UnityEvent DamageEvent;
    [SerializeField] UnityEvent DeathEvent;
    PathAsset path;
    float currentHealth;

    private void Start()
    {
        currentHealth = config.maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("got Collision");

        if (collision.CompareTag("PlayerProjectile"))
        {

            PlayerBullet col = collision.GetComponent<PlayerBullet>();
            currentHealth -= col.damage;
            col.Hit();
            currentGUIhp.SetValue(getHealthPerc());
            DamageEvent.Invoke();

        }

        if (currentHealth <= 0f)
        {
            GameManagerData._GameManagerData.AddScore(config.score);
            DeathEvent.Invoke();
        }
    }

    public float getHealthPerc()
    {
       float perc = currentHealth / config.maxHealth;
        return perc;
    }

}
