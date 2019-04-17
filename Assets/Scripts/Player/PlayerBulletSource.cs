using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

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
        StartCoroutine(CountDownAndShoot());

    }

    public void UpdateLevels()
    {
        ShotDelay = behaviour.shotDelayAtLevel[behaviour.data.GetLevel(UpgradeTypes.UpgradeType.FireRate)];
    }

    public IEnumerator CountDownAndShoot()
    {
        while (true)
        {
            behaviour.Fire(gameObject.transform);
            BulletSourceEvent.Invoke();
            Timer = ShotDelay;

            yield return new WaitForSeconds(Timer);
        }

    }

    [Button]
    public void startShooting()
    {
        StartCoroutine(CountDownAndShoot());
    }

}
