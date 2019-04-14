using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BulletSource : MonoBehaviour
{
    
    [SerializeField]BulletSourceConfig config;
    [SerializeField]UnityEvent BulletSourceEvent;
    private BulletPooler pooler;
    private float Timer;

   
    void Start()
    {
        pooler = BulletPooler.pooler;
        StartCoroutine(CountDownAndShoot());       
    }
 

    public IEnumerator CountDownAndShoot()
    {
        Timer = Random.value;
        while (true)
        {
            yield return new WaitForSeconds(Timer);
            Fire(gameObject.transform);
            BulletSourceEvent.Invoke();
            Timer = config.ShotDelay.Evaluate(Time.time);
           // Debug.Log(Timer);
            
        }
            
    }

    public void Fire(Transform source)
    {

       
        int numOfBullets =(int)config.NumOfBullets.Evaluate(Time.time);
        float pRotationAngle = config.coneAngle / numOfBullets;
        float currentOffset = config.RotationSpeed.Evaluate(Time.time);
        for (int i = 0; i < numOfBullets; i++)
        {


            GameObject laser = pooler.getPooledObject(config.Pool_ID);
            laser.SetActive(true);

            laser.transform.position = source.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, ((i - numOfBullets / 2) * pRotationAngle) + config.offsetZ + currentOffset);
            laser.GetComponent<Bullet>().speedOverTime = config.BulletSpeed;

        }
    }
}
