using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMove : MonoBehaviour {
    private float deltaX, deltaY;
    
    private Rigidbody2D rb;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0)
        {  
            Touch touch = Input.GetTouch(0);
         //   Debug.Log("jest dotyk");
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;
                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
            
        } else if (Input.anyKey)
        {
            rb.velocity = Vector2.zero;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1));

        }

        
	}
}
