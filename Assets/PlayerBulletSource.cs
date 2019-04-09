using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBulletSource : MonoBehaviour
{
    [SerializeField] public PlayerBulletBehaviour behaviour;
    [SerializeField] UnityEvent BulletSourceEvent;
    private float Timer;
    private float ShotDelay;

    void Start()
    {

        behaviour.GetTransform(this.gameObject);
        ShotDelay = behaviour.shotDelayAtLevel[behaviour.data.GetLevel(UpgradeTypes.UpgradeType.FireRate)];
        Timer = ShotDelay;

    }

    public void UpdateLevels()
    {
        ShotDelay = behaviour.shotDelayAtLevel[behaviour.data.GetLevel(UpgradeTypes.UpgradeType.FireRate)];
    }

    void Update()
    {
        CountDownAndShoot();
    }


    private void CountDownAndShoot()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            behaviour.Fire(gameObject.transform);
            BulletSourceEvent.Invoke();
            Timer = ShotDelay;
        }
    }

}
