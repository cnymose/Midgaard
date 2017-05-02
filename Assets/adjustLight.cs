using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustLight : MonoBehaviour {
    public Light spotlight;
    public Light dirLight;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            spotlight.intensity -= 0.1f;
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            spotlight.intensity += 0.1f;
        }
        if (Input.GetKey(KeyCode.F1))
        {
            dirLight.enabled = true;
        }
        if (Input.GetKey(KeyCode.F2))
        {
            dirLight.enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            dirLight.intensity += 0.1f;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            dirLight.intensity -= 0.1f;
        }
    }
}
