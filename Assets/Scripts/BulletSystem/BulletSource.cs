using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class BulletSource : MonoBehaviour
{
     
    [SerializeField]public BulletBehaviour behaviour;
    [SerializeField] UnityEvent BulletSourceEvent;
    private float Timer;
    private int positionInShotSequence;
   
    void Start()
    {

        behaviour.GetTransform(this.gameObject);
        Timer = behaviour.shotDelaySequence[0];
        positionInShotSequence = 0;
        
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
            if (positionInShotSequence == behaviour.shotDelaySequence.Length - 1)
            {
                positionInShotSequence = 0;
            }
            else
            {
                positionInShotSequence++;
            }

            Timer = behaviour.shotDelaySequence[positionInShotSequence];

        }
    }
}
