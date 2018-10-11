using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class MoveObj : MonoBehaviour {
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
	void Start () {
		ifjump = false;
		rig3d = GetComponent<Rigidbody> ();
		jumptimes = 0;
		turns1 = 0;
	}
	float Abs(float x)
    {
        if (x >= 0)
            return x;
        return -x;
    }
	// Update is called once per frame
	void Update () {
        //   Debug.Log(EditorUserBuildSettings.activeBuildTarget);
        //   Debug.Log(BuildTarget.WebGL);
        //  Debug.Log(BuildTarget.Android);
        //Debug.Log(BuildTarget.);
        bool onwebgl = false;
        if(onwebgl)
        {
            float movey= CrossPlatformInputManager.GetAxis("Vertical");
            if (movey > 0.5f && jumptimes <= 1) ifjump = true;
        }
        else 
		if (CrossPlatformInputManager.GetButtonDown("Jump")&&jumptimes<=1)
		{

			ifjump = true;
		}
	}
	void FixedUpdate(){
		movec ();
	}
	void movec(){
		Vector3 v = rig3d.velocity;
        if (ifground())
            jumptimes = 0;
		if (ifjump) {
            if(!ifground())
    			jumptimes++;
            ifjump = false;
            if(jumptimes <= 1)
    			v.y=jumpspeed;

		}
		movex = CrossPlatformInputManager.GetAxis("Horizontal");
        movez = CrossPlatformInputManager.GetAxis("Vertical");
        Debug.Log(movex);
        Debug.Log(movez);
        Vector3 last_size = transform.localScale;
        if ((movex > 0.1 || movex < -0.1))
            if (movex > 0)
            {
                last_size.x = -1 * Abs(last_size.x);
                transform.localScale = last_size;
            }
            else
            {
                last_size.x = Abs(last_size.x);
                transform.localScale = last_size;
            }
        if ((movez > 0.1 || movez < -0.1))
            if (movez > 0)
            {
                last_size.z = -1 * Abs(last_size.z);
                transform.localScale = last_size;
            }
            else
            {
                last_size.z = Abs(last_size.z);
                transform.localScale = last_size;
            }
        v.x = speed * movex;
        v.z = speed * movez;
        //rig2d.velocity = new Vector2 (speed*movex, rig2d.velocity.y);
        if (ifknock ()) {/*
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

	bool ifknock(){
		return GetComponentInChildren<knocktest> ().onknock;
	}
	bool ifground(){
        /*	RaycastHit2D ray = Physics2D.Raycast (transform.position, -transform.up, playerheight, walllayer);
            Debug.DrawLine (transform.position, transform.position + new Vector3 (0f, -playerheight, 0f), Color.red);
            if (ray.collider != null)
                return true;
            return false;*/
        return GetComponentInChildren<Groudtest>().is_onground;
	}
}
