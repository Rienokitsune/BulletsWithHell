
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    
    public AnimationCurve speedOverTime;
    public Rigidbody2D rb;
    public float Timer;
    public string ID;

    private void Start()
    {
        Timer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Timer = 0;
    }

    public abstract void FixedUpdate();

    public virtual void Hit()
    {
        BulletPooler.pooler.poolDictionary[ID].Enqueue(gameObject);
        gameObject.SetActive(false);
    }

}
