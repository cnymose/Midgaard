﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennaTalk : MonoBehaviour {

    public AudioClip[] clips;
    public AudioSource source;

	// Use this for initialization
	void Start () {

        source = GetComponent<AudioSource>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
