using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLink : MonoBehaviour
{
    public Transform followTarget;
    public float cameraDist;
    private float rotateDegree;
    // Use this for initialization
    void Start()
    {
        rotateDegree = 0;

    }

    // Update is called once per frame
    void Update()
    {

        rotateDegree += 0.01f;
        transform.position = followTarget.position + cameraDist  *(Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);
        transform.rotation = Quaternion.LookRotation(followTarget.position - transform.position);
    }
}
