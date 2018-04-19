using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	NodeScript[] nodes;
	//float angleMargin = 45;

    public float speed;

	// Use this for initialization
	void Start () {
		GameObject[] trackingObjects = GameObject.FindGameObjectsWithTag ("Trackers");
		nodes = new NodeScript[trackingObjects.GetLength(0)];

		for (int i = 0; i < trackingObjects.GetLength (0) && i < nodes.GetLength (0); i++) {
			if (trackingObjects [i].GetComponent<NodeScript> () != null)
				nodes [i] = trackingObjects [i].GetComponent<NodeScript> ();
			else
				Debug.LogErrorFormat (trackingObjects [i], "No NodeScript on Object!"); 
				// Logs an error message, if one then clicked on the message would the object put in as the first argument be highlighted;
				// In this case showing what object is missing the script or is wrongly tagged as a tracker.
		}

		// Just for some debugging
		if (nodes.GetLength (0) < 2)
			Debug.LogErrorFormat ("There seems to be less tracking objects than expected...");
		else if (nodes.GetLength (0) > 2)
			Debug.LogErrorFormat ("There seems to be more tracking objects than expected...");
		
	}
	
	// Update is called once per frame
	void Update	() {
		if (nodes.GetLength (0) >= 2) {
			float totalMagnitude = nodes[0].deltaPos.magnitude + nodes[1].deltaPos.magnitude;

			/*if (NodeScript.Above (nodes [0], nodes [1]) && CheckRequiredMovement(nodes[0].deltaPos))
				Move (nodes[0].deltaPos, totalMagnitude);
			else if (NodeScript.Above (nodes [1], nodes [0]) && CheckRequiredMovement(nodes[1].deltaPos))
				Move (nodes[1].deltaPos, totalMagnitude);*/

			if (CheckRequiredMovement (nodes [0].deltaPos) && CheckRequiredMovement (nodes [1].deltaPos)) {
				foreach (NodeScript node in nodes) {
					if (node.Above (nodes [0]) || node.Above (nodes [1]))
						Move (node.deltaPos, totalMagnitude);
				}
			}
		}

	}

	void Move(Vector3 direction, float distance) {
		if (direction.y != 0) direction.y = 0;
		float angle = Vector3.Angle(Vector3.forward, direction);

		transform.Translate ( new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * distance * speed);
	}



    void Move(Transform trans) {
		Move(trans, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

	void Move(Transform trans, float moveHorizontal, float moveVertical) {
		float angle = trans.rotation.eulerAngles.y * Mathf.Deg2Rad;

		transform.Translate(-moveHorizontal * speed * Mathf.Cos(angle) + moveVertical * speed * Mathf.Sin(angle), 
							0f, 
							moveHorizontal * speed * Mathf.Sin(angle) + moveVertical * speed * Mathf.Cos(angle));
		
	}



	bool CheckRequiredMovement(Vector3 direction) {
		return true;
		/*
		if (direction == Vector3.zero) return false; 
		float angle = Vector3.Angle(Vector3.right + Vector3.forward, direction);
		if (angle <= angleMargin || angle >= 180-angleMargin) {
			return true;
		} else
			return false;
		*/
	}

}
