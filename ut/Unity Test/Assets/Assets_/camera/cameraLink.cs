using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author:Yuandiaodiaodiao

Date:2018.10.13

Function:摄像机锁定玩家前方向上30度视角

没注释你写你🐎呢
*/
public class CameraLink : MonoBehaviour {
    public Transform followTarget;//player的transform
    public float cameraDist=100;//相机距离玩家的距离
    void Start () {
        //followTarget = GameObject.Find("player").transform;
    }
	

	void Update () {
        //修改位置
        transform.position = followTarget.position + cameraDist * (Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);
        //修改角度
        transform.rotation = Quaternion.LookRotation(followTarget.position - transform.position);

    }

    void FixedUpdate() {

	}

}
