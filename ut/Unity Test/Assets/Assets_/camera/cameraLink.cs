using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class cameraLink : MonoBehaviour

{

    public Transform followTarget;

    public float cameraDist;

    // Use this for initialization

    void Start()

    {

    }



    // Update is called once per frame

    void Update()

    {


        transform.position = followTarget.position + cameraDist * (Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);

        transform.rotation = Quaternion.LookRotation(followTarget.position - transform.position);

    }

}
