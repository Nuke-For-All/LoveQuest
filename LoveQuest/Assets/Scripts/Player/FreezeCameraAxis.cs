using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCameraAxis : MonoBehaviour {

    private float freezeYPos;

	// Use this for initialization
	void Start () {

        freezeYPos = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, freezeYPos, transform.position.z);
	}
}
