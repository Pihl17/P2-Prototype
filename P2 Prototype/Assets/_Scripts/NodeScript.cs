using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NodeScript : MonoBehaviour {

	public XRNode nodeType;

	Vector3 offSet;
	public Vector3 deltaPos;

	// Use this for initialization
	void Start () {
		offSet = transform.localPosition;
		TrackPosition(nodeType);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.localPosition;
		TrackPosition(nodeType);
		deltaPos = transform.localPosition - oldPos;
		if (Input.GetButton("Fire2") && nodeType == XRNode.RightHand || Input.GetButton("Jump") && nodeType == XRNode.LeftHand)
			offSet += InputTracking.GetLocalPosition(nodeType);
	}

	void TrackPosition (XRNode node) {
		transform.localPosition = InputTracking.GetLocalPosition(node) + offSet;
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
