using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_event : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.O))
			raycastStart ();
	}

	float distToSpawn = 25f;
	float hightToSpawn = 100f;
	public GameObject blob;
	public float heightOfObject = 1f;
	GameObject lastPlaced; 

	void raycastStart() {

		Vector3 FwH = new Vector3 (transform.forward.x, 0, transform.forward.z);
		Vector3 normFwH = Vector3.Normalize (FwH);
		Vector3 starHere = normFwH * distToSpawn + new Vector3 (0, hightToSpawn,0)+transform.position;

		RaycastHit hit;
		if (Physics.Raycast (starHere, -Vector3.up, out hit)) {
			
			Vector3 centerPoint = new Vector3 (hit.point.x, hit.point.y + (heightOfObject / 2), hit.point.z);

			if (hit.transform.name == "Terrain") {
				//Quaternion rot = Quaternion.FromToRotation (Vector3.up, hit.normal) * Quaternion.LookRotation(-transform.forward,transform.forward);
				//Quaternion rot = Quaternion.FromToRotation (Vector3.up, hit.normal)* Quaternion.LookRotation(transform.forward,blob.transform.forward);
				Quaternion rot = Quaternion.FromToRotation (Vector3.up, hit.normal) * Quaternion.LookRotation(new Vector3(transform.forward.x, 0, transform.forward.z),-new Vector3(transform.forward.x, 0, transform.forward.z));

				Destroy(lastPlaced);
				GameObject box = (GameObject)Instantiate(blob, centerPoint, rot);
				lastPlaced = box;
				Debug.Log (transform.forward);
				//box.transform.LookAt (transform.position.y);
//				Debug.Log ("center: " + centerPoint + " rotation:" + rot);
//				Debug.Log ("norm: " + hit.normal);
//				Debug.Log (Quaternion.FromToRotation (Vector3.up, hit.normal)+ " " +  Quaternion.LookRotation(-transform.forward,transform.forward));
			}
		}
	}

}
