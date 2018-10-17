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
    int is_move = 0; // 1 向右 -1 向左 2 向上 -2 向下
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
        is_move = 0;
        float movex = CrossPlatformInputManager.GetAxisRaw("Horizontal");//侧向移动
        float movez = CrossPlatformInputManager.GetAxisRaw("Vertical");//纵向
        if (Math.Abs(movez) > 0.2)//输入死区
        {
            v -= transform.forward * movez / Math.Abs(movez) * speed;
            float temp = movex / Math.Abs(movex);
            if (temp > 0)
                is_move = 2;
            else
                is_move = -2;
        }
        if (Math.Abs(movex) > 0.2)//输入死区
        {
            v -= transform.right * movex / Math.Abs(movex)  * speed;
            float temp = movex / Math.Abs(movex);
            if (temp > 0)
                is_move = 1;
            else
                is_move = -1;
        }
        rig3d.velocity = v;//修改速度
    }
    public int MoveCheck()
    {
        return is_move;
    }
    void FixedUpdate() {

    }

}
