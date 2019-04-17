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
        switch (collision)
        {
            case CircleCollider2D a when a.CompareTag("PlayerProjectile"):
                
                PlayerBullet col = collision.GetComponent<PlayerBullet>();
                currentHealth -= col.damage;
                col.Hit();
                currentGUIhp.SetValue(getHealthPerc());
                DamageEvent.Invoke();
                break;
            case PolygonCollider2D b when b.CompareTag("PlayerProjectile"):

                PlayerBladeController controller = collision.GetComponentInParent<PlayerBladeController>();
                currentHealth -= controller.getDamage();
                currentGUIhp.SetValue(getHealthPerc());
                DamageEvent.Invoke();
                break;
            
        }

        Debug.Log("got Collision");

       

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
