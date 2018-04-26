﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public NodeScript[] nodes;
	public float angleMargin = 45;
    public float distancemargin = 0.0001f;


    public float speed = 5;
	
	// Update is called once per frame
	void Update () {
		foreach (NodeScript node in nodes) {
			if (CheckRequiredMovement(node.deltaPos)) {
				Move(node.deltaPos.magnitude);
			}
		}
	}

	void Move(float distance) {
        GetComponent<Rigidbody>().AddForce(distance * speed * Vector3.right / Time.deltaTime);
    }

	bool CheckRequiredMovement(Vector3 direction) {
		if (direction == Vector3.zero || direction.magnitude < distancemargin) return false; 
		float angle = Vector3.Angle(Vector3.forward, direction);
		return (angle <= angleMargin || angle >= 180-angleMargin);

	}

}
