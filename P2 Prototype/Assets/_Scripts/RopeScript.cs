﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour {

	public GameObject [] planks =  new GameObject[1];
    public float newZ;
    public GameObject rope;
    public float newX = 1.1f;
    int rotateX = 90;
    private float newY = -0.9f;
    private float newYY = -0.1f;

    Vector3 ropePos = new Vector3();
    Vector3 reduce = new Vector3();
    Quaternion rot;
    Vector3 rot2 = new Vector3();
    //Vector3[] plank [2];





    // Use this for initialization
    void Start () {


        
      //  -newX,-newY 

    }
	
	// Update is called once per frame
	void Update () {
        PlaceRope();
    }

    void PlaceRope()
    {
        //Quaternion.Euler
     //  rot = Quaternion.Euler(planks[0].transform.rotation.x/4, planks[0].transform.rotation.y, planks[0].transform.rotation.z);
        // rot2 = rot.z*;
       // rot = Quaternion.Euler(planks[0].transform.localRotation.x,planks[0].transform.localRotation.y,planks[0].transform.localRotation.z);
            //= new Vector3(planks[0].transform.rotation.x, planks[0].transform.rotation.y, planks[0].transform.rotation.z);
            //   reduce = new Vector3(planks[1].transform.localPosition.x, planks[1].transform.localPosition.y, planks[1].transform.localPosition.z);
            // ropePos = new Vector3(planks[0].transform.localPosition.x + planks[1].transform.localPosition.x / 2, planks[0].transform.localPosition.y + planks[1].transform.localPosition.y / 2, planks[0].transform.localPosition.z + planks[1].transform.localPosition.z / 2);
        ropePos = new Vector3(planks[0].transform.position.x-newX, planks[0].transform.position.y+newY, planks[0].transform.position.z+newZ    );
       // print(reduce);
         rope.transform.position = ropePos;
      //  rope.transform.rotation = rot;
    }


}

