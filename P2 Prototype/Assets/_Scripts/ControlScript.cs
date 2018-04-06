using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

	Tracking[] trackers;
	float angleMargin = 45;

	public float speed;

	// Use this for initialization
	void Start () {
		GameObject[] trackingObjects = GameObject.FindGameObjectsWithTag ("Trackers");
		trackers = new Tracking[trackingObjects.GetLength(0)];
		for (int i = 0; i < trackingObjects.GetLength(0); i++) {
			trackers [i] = trackingObjects[i].GetComponent<Tracking>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < trackers.GetLength(0); i++) {
			if (CheckRequiredMovement(trackers[i].deltaPos))
				Move(trackers[i].deltaPos.magnitude*speed);
		}
	}

	void Move(float forward) {
		transform.Translate(0,0,forward,Space.Self);
	}

	bool CheckRequiredMovement(Vector3 direction) {
		if (direction == Vector3.zero) return false; 
		float angle = Vector3.Angle(direction, Vector3.up);
		print(angle);
		if (angle <= angleMargin || angle >= 180-angleMargin) {
			return true;
		} else
			return false;
	}

}
