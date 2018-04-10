using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour {

	public enum TypeOfControl {none, mouse, controllerLeft, controllerPS4Right, controllerXBoneRight};
	public TypeOfControl controlType;

	Transform camTrans;
	public float disFromCam;
	public float deltaDis;
	public float controllerSpeed = 2;

	Vector3 pos = new Vector3();

	public Vector3 deltaPos;

	// Use this for initialization
	void Start () {
		camTrans = Camera.main.transform;
		if (controlType == TypeOfControl.mouse)
			UpdatePositionByMouse ();
		else if (controlType == TypeOfControl.controllerLeft)
			UpdatePositionByController(0,0);
		else if (controlType == TypeOfControl.controllerPS4Right || controlType == TypeOfControl.controllerXBoneRight)
			UpdatePositionByController(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 oldPos = pos;
		if (controlType == TypeOfControl.mouse) {
			UpdatePositionByMouse ();
		} else if (controlType == TypeOfControl.controllerLeft) {
			UpdatePositionByController (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		} else if (controlType == TypeOfControl.controllerXBoneRight) {
			UpdatePositionByController (Input.GetAxis("HorizontalXBone"), Input.GetAxis("VerticalXBone"));
		} else if (controlType == TypeOfControl.controllerPS4Right) {
			UpdatePositionByController (Input.GetAxis("HorizontalPS4"), Input.GetAxis("VerticalPS4"));
		}
		deltaPos = pos - oldPos;
	}



	void UpdatePositionByMouse() {
		pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

		float opp = -(Input.mousePosition.x - Screen.width/2)*deltaDis;
		transform.position = new Vector3 (
			-disFromCam * opp * Mathf.Cos (CamAngle()) + disFromCam * Mathf.Sin (CamAngle()),
			(Input.mousePosition.y - Screen.height / 2) * disFromCam * deltaDis,
			disFromCam * opp * Mathf.Sin (CamAngle()) + disFromCam * Mathf.Cos (CamAngle())
		)+camTrans.position;
	}

	void UpdatePositionByController(float right, float up) {
		pos += (-right*Vector3.right + up*Vector3.up)*controllerSpeed*Time.deltaTime;
		transform.position = new Vector3 (
			-disFromCam * pos.x * Mathf.Cos (CamAngle()) + disFromCam * Mathf.Sin (CamAngle()),
			pos.y * disFromCam,
			disFromCam * pos.x * Mathf.Sin (CamAngle()) + disFromCam * Mathf.Cos (CamAngle())
		)+camTrans.position;
	}



	float CamAngle() {
		return camTrans.rotation.eulerAngles.y * Mathf.Deg2Rad;
	}

}
