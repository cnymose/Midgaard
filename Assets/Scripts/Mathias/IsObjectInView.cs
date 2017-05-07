using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObjectInView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Camera cam;
	public GameObject obj;
	public bool onScreen;
	// Update is called once per frame
	void Update () {
		Vector3 screenPoint = cam.WorldToViewportPoint(obj.transform.position);
		onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
	}

}
