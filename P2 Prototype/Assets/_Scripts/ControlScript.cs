using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

	public TrackingScript[] trackers;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < trackers.GetLength(0); i++) {
			if (CheckRequiredMovement(trackers[i])) 
				Move(trackers[i].deltaPos.magnitude*speed);
		}

		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) Rotate(1);
		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) Rotate (-1);

	}


	void Move(float forward) {
		transform.Translate(0,0,forward,Space.Self);
	}


	void Rotate(float right) {
		transform.Rotate (Vector3.up, right*30*Time.deltaTime);
	}


	bool CheckRequiredMovement(TrackingScript tracker) {
		Vector3 normalisedTracker = tracker.deltaPos.normalized;
		float angle = Mathf.Atan2 (normalisedTracker.x, normalisedTracker.y) % Mathf.PI;
		if (angle < Mathf.PI/8 && angle > -Mathf.PI/8) return true;
		else return false;
	}

}
