using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlanksScriptOne : MonoBehaviour
{

    public GameObject prePlank ;
    Vector3 plankPos = new Vector3();
   
  // public GameObject ThisPlank;
    float nX;
    float nY;
        float nZ;


    void Start()
    {

         
    }


    // Update is called once per frame
    void Update()
{
        nX = gameObject.transform.position.x - prePlank.transform.position.x;
        nY = gameObject.transform.position.y - prePlank.transform.position.y;
        nZ = gameObject.transform.position.z - prePlank.transform.position.z;
        //  ropePos = new Vector3(planks[0].transform.position.x - newX, planks[0].transform.position.y + newY, planks[0].transform.position.z + newZ);
        // print(reduce);
        //  rope.transform.position = ropePos;
        plankPos = new Vector3(gameObject.transform.position.x, prePlank.transform.position.y, prePlank.transform.position.z);
        gameObject.transform.position = plankPos;

     
    }

    
   


  
}