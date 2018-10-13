using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author:

Date:

Function:

没注释你写你🐎呢
*/
public class CameraLink : MonoBehaviour {
    public Transform followTarget;
    public float cameraDist=100;
    void Start () {
        //followTarget = GameObject.Find("player").transform;
    }
	

	void Update () {
        transform.position = followTarget.position + cameraDist * (Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);        transform.rotation = Quaternion.LookRotation(followTarget.position - transform.position);
    }

    void FixedUpdate() {

	}

}
