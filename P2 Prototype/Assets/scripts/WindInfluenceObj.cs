using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=iCMhrKOuBZg

public class WindInfluenceObj : MonoBehaviour {

	public bool inWindZone = false;
	public GameObject windZone;
	Rigidbody rb;
	//public WindArea windZone;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		//windZone = GetComponent<WindArea>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (inWindZone) 
		{
			rb.AddForce ((windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength));
		}
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "windArea") 
		{
			windZone = col.gameObject;
			inWindZone = true;
		}
		
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "windArea") 
		{
			windZone = col.gameObject;
			inWindZone = false;
		}
	}
}
