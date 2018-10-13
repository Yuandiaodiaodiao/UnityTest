﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudTest : MonoBehaviour {
    public bool is_onground;
	// Use this for initialization
	void Start () {
        is_onground = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            is_onground = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            is_onground = false;
        }
    }
}
