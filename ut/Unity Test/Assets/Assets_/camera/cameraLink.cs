using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class cameraLink : MonoBehaviour

{

    public Transform followTarget;

    public float cameraDist;

<<<<<<< HEAD


=======
>>>>>>> 48d0eea7c0c0e006e69d343b1afcff2c8af4c69b
    // Use this for initialization

    void Start()

    {
<<<<<<< HEAD


=======
>>>>>>> 48d0eea7c0c0e006e69d343b1afcff2c8af4c69b

    }



    // Update is called once per frame

    void Update()

    {

<<<<<<< HEAD


        transform.position = followTarget.position + cameraDist * (Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);

=======
        transform.position = followTarget.position + cameraDist  *(Quaternion.AngleAxis(-30, followTarget.right) * followTarget.forward);
>>>>>>> 48d0eea7c0c0e006e69d343b1afcff2c8af4c69b
        transform.rotation = Quaternion.LookRotation(followTarget.position - transform.position);

    }

}
