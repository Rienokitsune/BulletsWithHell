using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour {

    [SerializeField] float scrollingSpeed = 0.3f;
    Material bg;
    Vector2 offset;
    private void Start()
    {
        bg = gameObject.GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollingSpeed);
    }
    // Update is called once per frame
    void Update () {
        bg.mainTextureOffset += offset * Time.deltaTime;
	}
}
