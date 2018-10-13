using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author:

Date:

Function:

没注释你写你🐎呢
*/
public class AnimateController : MonoBehaviour {
    public GameObject player;
	void Start () {

	}
	

	void Update () {
        float a =GetComponentInParent<MoveObj>().speed;

    }
	
	void FixedUpdate() {

	}

}
