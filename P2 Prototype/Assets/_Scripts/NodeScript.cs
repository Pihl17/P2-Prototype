using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NodeScript : MonoBehaviour {

	public enum nodeType {left, right};
	public nodeType typeOfNode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (typeOfNode == nodeType.left)
			UpdatePosition (XRNode.LeftHand);
		else if (typeOfNode == nodeType.right) 
			UpdatePosition (XRNode.RightHand);
	}


	void UpdatePosition(XRNode node) {
		transform.position = InputTracking.GetLocalPosition(node);
		transform.rotation = InputTracking.GetLocalRotation(node);
	}
}
