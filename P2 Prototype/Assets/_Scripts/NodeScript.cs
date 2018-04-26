using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NodeScript : MonoBehaviour {

	public XRNode nodeType; //Which device the object will react to, assigned through the editor.
	public Vector3 deltaPos;
	Vector3 oldPos;

	// Use this for initialization
	void Start () {
		oldPos = TrackPosition(nodeType);
	}
	
	// Update is called once per frame
	void Update () {
        //Calculates the vector it had been moved since last frame.
		deltaPos = TrackPosition(nodeType) - oldPos;
		oldPos = TrackPosition(nodeType);
	}

    //Returns the local position of the specified device.
	Vector3 TrackPosition (XRNode node) {
		return InputTracking.GetLocalPosition(node);
	}

}
