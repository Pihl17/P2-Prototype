using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NodeScript : MonoBehaviour {

	public XRNode nodeType;
	public Vector3 deltaPos;
	Vector3 oldPos;

	// Use this for initialization
	void Start () {
        InputTracking.disablePositionalTracking = true;
		oldPos = TrackPosition(nodeType);
	}
	
	// Update is called once per frame
	void Update () {
		deltaPos = TrackPosition(nodeType) - oldPos;
		oldPos = TrackPosition(nodeType);
	}

	Vector3 TrackPosition (XRNode node) {
		return InputTracking.GetLocalPosition(node);
	}

}
