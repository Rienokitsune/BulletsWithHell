using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{

    [ShowInInspector]bool hasEnded;
    [ShowInInspector]bool PlayerDead;
     
    public Level Level;
    [SerializeField] public GameManagerData data;
    [SerializeField] public EnemySpawner spawner;
    [SerializeField] UnityEvent GameEndedEvent;
    [SerializeField] UnityEvent GameWonEvent;
    [SerializeField] UnityEvent GameLostEvent;
    bool stateChanged = false;

    private void Awake()
    {
        data.Reset();
        spawner.setScript(Level);
        data.level = Level;
        hasEnded = false;
        PlayerDead = false;
        
    }

    private void Update()
    {
        data.timer += Time.deltaTime;
        if (!stateChanged)
        {
            if (hasEnded && PlayerDead)
            {
                GameEndedEvent.Invoke();
                GameLostEvent.Invoke();
                Debug.Log("Game Lost");
                    stateChanged = true;
                    return;
            }
            else if(hasEnded)
            {
                GameEndedEvent.Invoke();
                Debug.Log("Game won");
                GameWonEvent.Invoke();
                stateChanged = true;
                return;
            }
        }
       
    }

    public void AddKill()
    {
        data.kills += 1;       
    }
    public void AddEnemy()
    {
        data.enemiesSpawned += 1;
    }

    public void AddItemCollected()
    {
        data.itemsCollected += 1;
    }

    public void AddItemSpawned()
    {
        data.itemsSpawned += 1;
    }

    public void PlayerDied()
    {
        PlayerDead = true;
    }

    public void GameEnded()
    {
        hasEnded = true;
    }
    
    
}
