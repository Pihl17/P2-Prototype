using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUserDirectionScript : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = new Color(0,255,0);
		Gizmos.DrawRay (transform.position, 50*Vector3.right);
		Gizmos.DrawWireMesh (GetComponent<MeshFilter> ().sharedMesh, transform.position, transform.rotation, transform.lossyScale);
	}

}
