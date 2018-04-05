using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float rotate = Input.GetAxis("Rotate");

        transform.Rotate(0f, rotate * speed, 0f);
	}
}
