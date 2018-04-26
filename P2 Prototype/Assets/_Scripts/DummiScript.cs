using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummiScript : MonoBehaviour {
	public float speed =2f ;
	public Rigidbody rb;

	void Start ()
	{
		
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveVertical, 0.0f, moveHorizontal);
		rb.AddForce (movement * speed);

	

	}
}
