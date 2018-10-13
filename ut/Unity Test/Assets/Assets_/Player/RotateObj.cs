using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotateObj : MonoBehaviour
{
    private bool isRotating;//正在旋转  加锁
    [SerializeField] private float rotateSpeed = 1;//旋转速度 0.x秒旋转完成
    [SerializeField] private float rotateAngel = 45f;//单次旋转角度
    private float rotateDirection;//旋转方向
    private float lastAngel;//剩余旋转角度
    void Start() {
        isRotating = false;
        lastAngel = 0f;
    }

    // Update is called once per frame
    void Update() {
        Rotate();
    }
    void Rotate() {
        //旋转角色

        if (isRotating) {//正在旋转
            float rotateA = rotateAngel / (rotateSpeed / (1f / 60f));
            if (rotateA <= lastAngel)
                transform.Rotate(new Vector3(0, rotateDirection * rotateA, 0));
            else {
                transform.Rotate(new Vector3(0, rotateDirection * lastAngel, 0));
                isRotating = false;
            }
            lastAngel -= rotateA;
        }
        else {

            bool onButtonQ = CrossPlatformInputManager.GetButtonDown("Q");//侧向移动
            bool onButtonE = CrossPlatformInputManager.GetButtonDown("E");//纵向
            if (onButtonQ) {
                Debug.Log("Q");
                isRotating = true;
                rotateDirection = 1f;
                lastAngel = 45f;
            }
            else {
                if (onButtonE) {
                    Debug.Log("E");
                    isRotating = true;
                    rotateDirection = -1f;
                    lastAngel = 45f;
                }
            }
        }

    }
}
