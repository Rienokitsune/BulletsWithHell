using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathMover : MonoBehaviour {

    public PathAsset path;

    public abstract void Move();

    private void Update()
    {
        Move();
    }

    public void SetPath(PathAsset path)
    {
        this.path = path;
    }


}
