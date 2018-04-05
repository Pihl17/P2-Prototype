using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour {

	public enum TypeOfControl {mouse, controller};
	public TypeOfControl controlType;

	Transform camTrans;
	public float disFromCam;
	public float deltaDis;

	public Vector3 deltaPos;

	// Use this for initialization
	void Start () {
		camTrans = Camera.main.transform;
		if (controlType == TypeOfControl.mouse)
			UpdatePositionByMouse ();
		else if (controlType == TypeOfControl.controller)
			UpdatePositionByController ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = transform.position;
		if (controlType == TypeOfControl.mouse) {
			UpdatePositionByMouse ();
		} else if (controlType == TypeOfControl.controller) {
			UpdatePositionByController ();
		}
		deltaPos = transform.position - oldPos;
	}

	void UpdatePositionByMouse() {
		transform.position = new Vector3 (
			Input.mousePosition.x - Screen.width / 2,
			Input.mousePosition.y - Screen.height / 2,
			1 / deltaDis + camTrans.position.z / (disFromCam * deltaDis)
		) * disFromCam * deltaDis;
	}

	void UpdatePositionByController() {
		
	}
}
