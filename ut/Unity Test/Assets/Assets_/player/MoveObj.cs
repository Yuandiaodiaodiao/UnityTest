using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/*
Author:Yuandiaodiaodiao

Date:2018.10.14

Function:移动class

没注释你写你🐎呢
*/
public class MoveObj : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rig3d;
    public int moveDirection;
    void Start() {
        rig3d = GetComponent<Rigidbody>();//3d刚体
    }


    void Update() {
        move();
    }
    void move() {
        Vector3 v = rig3d.velocity;//缓存速度
        v.x = 0;
        v.z = 0;
        float movex = CrossPlatformInputManager.GetAxisRaw("Horizontal");//侧向移动
        float movez = CrossPlatformInputManager.GetAxisRaw("Vertical");//纵向
        if (Math.Abs(movex) > 0.2)//输入死区
        {
            v -= transform.right * movex / Math.Abs(movex)  * speed;
        }
        if (Math.Abs(movez) > 0.2)//输入死区
        {
            v -= transform.forward * movez / Math.Abs(movez)  * speed;
        }
        rig3d.velocity = v;//修改速度

    }
    void FixedUpdate() {

    }

}
