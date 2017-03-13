﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interact : MonoBehaviour { //This script can be placed on any object that we want the player
                                        //to be able to interact with. We can point to any gameobjects class/method,
                                        //with the UnityEvent and invoke the selected method.

    public UnityEvent method;
    public bool interacted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void On_Interact() {             //When this method is called from outside this script
        interacted = true;
        method.Invoke();                    //Call the method that we select in the inspector for this given object
    }
}