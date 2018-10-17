using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author:

Date:

Function:

没注释你写你🐎呢
*/
public class AnimController_ : MonoBehaviour {

    public Animator Anim;
    private MoveObj temp; 
	void Start (){
        temp = GetComponentInParent<MoveObj>();
	}
	void Update () {
        int MoveState = temp.MoveCheck();
        bool is_move = false;
        if (MoveState != 0)
            is_move = true;
        Debug.Log(is_move);
        Anim.SetBool("IsMove",is_move);
    }
	
	void FixedUpdate() {

	}

}
