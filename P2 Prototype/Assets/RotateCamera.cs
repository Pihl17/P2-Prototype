﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float speed;
    public float rotate;
    private float x;
    private float y;
    private float rotationSpeed;
    // Use this for initialization
    void Start () {
        x = 0f;
        y = 0;
        rotationSpeed = 0;
	}
	
	// Update is called once per frame, after update on every game object has rendered/updated
	void LateUpdate () {



        x += Input.GetAxis("Mouse X") * rotationSpeed;
        y += -Input.GetAxis("Mouse Y") * rotationSpeed;


        //  Camera.main.ScreenPointToRay(Input.mousePosition);

        //  float rotate = Input.mousePosition;

        //  transform.Rotate(0f, rotate * speed, 0f);
    }
}
