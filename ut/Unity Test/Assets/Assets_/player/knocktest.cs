using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockTest : MonoBehaviour {
	public bool onknock;
	// Use this for initialization
	void Start () {
		onknock = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "ground") {
			onknock = true;
		}

	}
	void OnTriggerExit(Collider other){
		if (other.tag == "ground") {
			onknock = false;
		
		}
	}
}
