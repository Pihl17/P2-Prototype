using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    public float strength;
    public Vector3 direction;

    private void Update()
    {
        transform.Translate(0f, -0.01f, 0f);
    }
}
