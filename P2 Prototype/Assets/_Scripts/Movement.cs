using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public NodeScript[] nodes; //The array storing the nodes, they are assigned through the editor.
	public float angleMargin = 45;
    public float distancemargin = 0.0001f;

    public float speed = 5;
    Vector3 moveDirection = Vector3.right; public Vector3 GetMoveDirection() { return moveDirection; } //Used so that the ShowUserDirectionScript can get the direction.
   

    // Update is called once per frame
    void Update () {
		foreach (NodeScript node in nodes) {
			if (CheckRequiredMovement(node.deltaPos)) {
				Move(node.deltaPos.magnitude);
			}
		}
	}

    //Makes the user move by adding a force to their object.
	void Move(float distance) {
        GetComponent<Rigidbody>().AddForce(distance * speed * moveDirection / Time.deltaTime);
    }

    //Checks if the movement of the tracking devices are in the correct direction and distance.
	bool CheckRequiredMovement(Vector3 direction) {
		if (direction == Vector3.zero || direction.magnitude < distancemargin) return false; 
		float angle = Vector3.Angle(new Vector3(0,1,1), direction);
		return (angle <= angleMargin || angle >= 180-angleMargin);

	}

}
