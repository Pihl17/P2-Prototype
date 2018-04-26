using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUserDirectionScript : MonoBehaviour {

    public float distance;

    //Draws gizmos (Icons for the camera, lines, etc.) that can be viewed in the editor window (and in the scene view, if enabled there)
	void OnDrawGizmos() {
		Gizmos.color = new Color(0,255,0);
        Gizmos.DrawRay(transform.position, distance * GetComponent<Movement>().GetMoveDirection()); //draws the line that the user's moving through.
		Gizmos.DrawWireMesh (GetComponent<MeshFilter> ().sharedMesh, transform.position, transform.rotation, transform.lossyScale); //Draws the mesh
	}

}
