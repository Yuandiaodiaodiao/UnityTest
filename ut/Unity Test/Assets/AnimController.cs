using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author:

Date:

Function:

没注释你写你🐎呢
*/
public class AnimController : MonoBehaviour {

    public Animator Anim_;
	void Start (){
        GetComponentInParent<MoveObj>();
	}
	void Update () {
        int MoveState = gameObject.GetComponentInParent<MoveObj>().MoveCheck();
        bool is_move = false;
        if (MoveState > 0)
            is_move = true;
        Anim_.SetBool("IsMove",is_move);
    }
	
	void FixedUpdate() {

	}

}
