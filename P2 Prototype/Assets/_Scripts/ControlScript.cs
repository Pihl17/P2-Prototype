using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

	public Tracking[] trackers;
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
	}

	void Move(float forward) {
		transform.Translate(0,0,forward,Space.Self);
	}

	bool CheckRequiredMovement(Tracking tracker) {
		Vector3 normalisedTracker = tracker.deltaPos.normalized;
		float angle = Mathf.Atan2 (normalisedTracker.x, normalisedTracker.y) % Mathf.PI;
		if (angle < Mathf.PI / 8 && angle > -Mathf.PI / 8)
			return true;
		else
			return false;
	}

}
