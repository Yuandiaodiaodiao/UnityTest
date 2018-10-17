using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class RotateObj : MonoBehaviour
{
    public float fixSpeed;//旋转修正速度
    private bool isRotating;//正在旋转  加锁
    [SerializeField] private float rotateSpeed = 1;//旋转速度 0.x秒旋转完成
    [SerializeField] private float rotateAngel = 45f;//单次旋转角度
    private float rotateDirection;//旋转方向
    private float lastAngel;//剩余旋转角度
    void Start() {
        isRotating = false;//初始不旋转
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }
    void Rotate() {
        //旋转角色

        if (isRotating) {//正在旋转
            float rotateA = rotateAngel / (rotateSpeed / (1f / 60f));//算出每帧角度移动
            rotateA += AngelFix(lastAngel, rotateAngel);
            if (rotateA <= lastAngel)//旋转对应角度
                transform.Rotate(new Vector3(0, rotateDirection * rotateA, 0));
            else {
                //最后一次旋转 
                transform.Rotate(new Vector3(0, rotateDirection * lastAngel, 0));
                isRotating = false;//旋转结束
            }
            //修改剩余旋转值
            lastAngel -= rotateA;
        }
        else {//非旋转状态 准备接受键盘输入

            bool onButtonQ = CrossPlatformInputManager.GetButtonDown("Q");//逆时针
            bool onButtonE = CrossPlatformInputManager.GetButtonDown("E");//顺时针
            if (onButtonQ) {
                Debug.Log("Q");
                //下一帧 开启旋转
                //设定旋转方向
                //设置剩余旋转角度 下同
                isRotating = true;
                rotateDirection = -1f;
                lastAngel = rotateAngel;
            }
            else {
                if (onButtonE) {
                    Debug.Log("E");
                    isRotating = true;
                    rotateDirection = 1f;
                    lastAngel = rotateAngel;
                }
            }
        }

    }

    float AngelFix(float last,float all ) {
        //旋转修正为cos
        float x = last / all;
        //   float fx = -4 * (x * x) + 4 * x-1;
        //  return fixSpeed * float.Parse((fx).ToString());

        //三角函数映射
        double mapY = Math.PI * 2 * x;
        return fixSpeed * float.Parse((-Math.Cos(mapY)).ToString());
    }
}
