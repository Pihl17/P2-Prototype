using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

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
		//move(transform);
		for (int i = 0; i < trackers.GetLength(0); i++) {
			if (CheckRequiredMovement(trackers[i].deltaPos))
				Move(Camera.main.transform, 0, trackers[i].deltaPos.magnitude*speed);
		}
	}

    public void Move(Transform trans)
    {
		Move(trans, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		/*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float angle = trans.rotation.eulerAngles.y * Mathf.Deg2Rad;

        transform.Translate(moveHorizontal * speed * Mathf.Cos(angle)-moveVertical*speed - moveVertical * speed * Mathf.Sin(angle), 0f, moveHorizontal * speed * Mathf.Sin(angle) + moveVertical * speed + moveVertical * speed * Mathf.Cos(angle));
        */
    }

	public void Move(Transform trans, float moveHorizontal, float moveVertical) {
		float angle = trans.rotation.eulerAngles.y * Mathf.Deg2Rad;

		transform.Translate(-moveHorizontal * speed * Mathf.Cos(angle) + moveVertical * speed * Mathf.Sin(angle), 
							0f, 
							moveHorizontal * speed * Mathf.Sin(angle) + moveVertical * speed * Mathf.Cos(angle));
		
	}

	bool CheckRequiredMovement(Vector3 direction) {
		if (direction == Vector3.zero) return false; 
		float angle = Vector3.Angle(direction, Vector3.up);
		if (angle <= angleMargin || angle >= 180-angleMargin) {
			return true;
		} else
			return false;
	}

}
