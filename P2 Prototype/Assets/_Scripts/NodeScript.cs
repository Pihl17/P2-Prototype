using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NodeScript : MonoBehaviour {

	public enum nodeType {leftHand, rightHand};
	public nodeType typeOfNode;

	public Vector3 deltaPos;

	// Use this for initialization
	void Start () {
		TrackPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.position;
		TrackPosition ();
		deltaPos = transform.position - oldPos;
	}

	void TrackPosition () {
		if (typeOfNode == nodeType.leftHand)
			TrackPosition (XRNode.LeftHand);
		else if (typeOfNode == nodeType.rightHand)
			TrackPosition (XRNode.RightHand);
	}

	void TrackPosition (XRNode node) {
		transform.localPosition = InputTracking.GetLocalPosition(node);
		transform.rotation = InputTracking.GetLocalRotation(node);
	}

	public Vector3 getPosition() {
		return transform.position;
	}

	static public bool Above(NodeScript node1, NodeScript node2) {
		return node1.getPosition().y > node2.getPosition().y;
	}

	public bool Above(NodeScript node) {
		return Above(this, node);
	}

}
