using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        move(transform);
	}
    public void move(Transform trans)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float angle = trans.rotation.eulerAngles.y * Mathf.Deg2Rad;

        transform.Translate(moveHorizontal * speed * Mathf.Cos(angle)-moveVertical*speed - moveVertical * speed * Mathf.Sin(angle), 0f, moveHorizontal * speed * Mathf.Sin(angle) + moveVertical * speed + moveVertical * speed * Mathf.Cos(angle));
        
    }
}
