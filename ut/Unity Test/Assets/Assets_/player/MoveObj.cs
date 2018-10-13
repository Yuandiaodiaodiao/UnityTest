using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class MoveObj : MonoBehaviour
{
    private bool ifjump;
    public float jumpspeed;
    private Rigidbody rig3d;
    public LayerMask walllayer;
    public float speed;
    private int jumptimes;
    private float movex;
    private float movez;
    private int turns1;
    [SerializeField] private float knockg;
    [SerializeField] private float playerheight;
  
    // Use this for initialization
    void Start() {
        ifjump = false;
        rig3d = GetComponent<Rigidbody>();
        jumptimes = 0;
        turns1 = 0;
    }
    float Abs(float x) {
        if (x >= 0)
            return x;
        return -x;
    }
    // Update is called once per frame
    void Update() {
     
        //   Debug.Log(EditorUserBuildSettings.activeBuildTarget);
        //   Debug.Log(BuildTarget.WebGL);
        //  Debug.Log(BuildTarget.Android);
        //Debug.Log(BuildTarget.);
        bool onwebgl = false;
        if (onwebgl) {
            float movey = CrossPlatformInputManager.GetAxis("Vertical");
            if (movey > 0.5f && jumptimes <= 1) ifjump = true;
        }
        else
        if (CrossPlatformInputManager.GetButtonDown("Jump") && jumptimes <= 1) {

            ifjump = true;
        }
    }
    void FixedUpdate() {

        movec();
    }
   
    void movec() {


        Vector3 v = rig3d.velocity;
        if (ifground())
            jumptimes = 0;
        if (ifjump) {
            if (!ifground())
                jumptimes++;
            ifjump = false;
            if (jumptimes <= 1)
                v.y = jumpspeed;

        }
        movex = CrossPlatformInputManager.GetAxisRaw("Horizontal");//侧向移动
        movez = CrossPlatformInputManager.GetAxisRaw("Vertical");//纵向


        Vector3 last_size = transform.localScale;
        v.x = 0;
        v.z = 0;
        if (Math.Abs(movex) > 0.2)//输入死区
        {
            Debug.Log(transform.right);
            v += transform.right * movex / Math.Abs(movex) * -1 * speed;
        }
        if (Math.Abs(movez) > 0.2)//输入死区
        {
            v += transform.forward * movez / Math.Abs(movez) * -1 * speed;
        }

        //rig2d.velocity = new Vector2 (speed*movex, rig2d.velocity.y);
        if (ifknock()) {/*
			if (turns1 == 10) {
				turns1 = 0;
			} else {*/
            turns1++;
            //Debug.Log ("speed--");
            v.x = rig3d.velocity.x;
            v.z = rig3d.velocity.z;
            //rig2d.velocity = new Vector2 (rig2d.velocity.x, rig2d.velocity.y - knockg);}
        }
        //
        rig3d.velocity = v;
    }

    bool ifknock() {
        return GetComponentInChildren<KnockTest>().onknock;
    }
    bool ifground() {
        /*	RaycastHit2D ray = Physics2D.Raycast (transform.position, -transform.up, playerheight, walllayer);
            Debug.DrawLine (transform.position, transform.position + new Vector3 (0f, -playerheight, 0f), Color.red);
            if (ray.collider != null)
                return true;
            return false;*/
        return GetComponentInChildren<GroudTest>().is_onground;
    }
}
