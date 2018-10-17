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

    public Animator Anim;//控制器
    private MoveObj State; //当前的状态
	void Start (){
        State = GetComponentInParent<MoveObj>();
	}
	void Update () {
        int MoveState = State.MoveCheck();//获得当前的移动状态
        bool is_move = false;
        if (MoveState != 0)
            is_move = true;//不为零代表移动
        Debug.Log(is_move);
        Anim.SetBool("IsMove",is_move);//修改动画参数
    }
	
	void FixedUpdate() {

	}

}
