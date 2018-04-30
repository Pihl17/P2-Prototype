using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigdeScript : MonoBehaviour {
    public HingeJoint  hinge;
    public GameObject dummi;
    Vector3 axis = new Vector3();
    Vector3 anchor = new Vector3();
   
    // Use this for initialization
    void Start () {

        hinge = GetComponent<HingeJoint>();
        //   Joint.axis axis = hinge.axis;
        hinge.axis = axis;
        hinge.anchor = anchor;
      //   axis = new Vector3(0, 0, 0);
       //anchor = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate () {
     //   OnBrigde();

    }
    // Captain On the bridge
    void OnBrigde()
    {


        if (dummi.transform.localPosition.x > 207)
        {
           
            hinge.axis = new Vector3(1f, 0, 0);
            hinge.anchor = new Vector3(1.2f, 0, 0.2f);
            print("does it work?");
        }
            
        





    }
       
   

}
