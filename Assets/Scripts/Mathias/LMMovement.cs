using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMMovement : MonoBehaviour {

	public GameObject target; 

	public float dist = 0.5f;
	public float hight = 0.5f;
	public float disapdist = 20;

	Vector3 startMarker;
	Vector3 endMarker;
	Vector3 origin;
	float speed = 0.1F;
	private float startTime;
	private float journeyLength;

	void Start() {
		startMarker = transform.position;
		origin = transform.position;
		endMarker = new Vector3 (origin.x + Random.Range (0f, dist), origin.y + Random.Range (0f, hight), origin.z + Random.Range (0f, dist));
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker, endMarker);

		intialLightStrength = GetComponent<Light> ().intensity;
		startPart ();
	}


	void Update() {
		turnOffIfNear ();
		speedOfmove ();
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Slerp(startMarker, endMarker, fracJourney);
		if (fracJourney > 0.9) {
			startMarker = transform.position;
			endMarker = new Vector3 (origin.x + Random.Range (0f, dist), origin.y + Random.Range (0f,hight), origin.z + Random.Range (0f, dist));
			journeyLength = Vector3.Distance(startMarker, endMarker);
			startTime = Time.time;
		}
	}
		

	void speedOfmove(){
		speed = (Mathf.Cos (((Time.time - startTime) * 0.5f) / journeyLength) * -1 + 1) / 2;	
	}

	void turnOffIfNear(){
		float distanceTotarget = Vector3.Distance (target.transform.position, transform.position);
		Renderer rend = GetComponent<Renderer> ();
		Renderer cRend = transform.GetChild(0).GetComponent<Renderer> ();
		if (distanceTotarget < disapdist) {
			rend.enabled = false;
			turndownlights ();
		} else {
			rend.enabled = true;
			GetComponent<Light> ().intensity = 3;
			hasBeenOff = true;
			ChangeTintColor (startTint);
		}

		if (GetComponent<Light> ().intensity > 0 && rend.enabled == false) {
			explode ();
		} else if (GetComponent<Light> ().intensity == 0) {
			cRend.enabled = rend.enabled;
			explode ();
		} else {
			cRend.enabled = rend.enabled;
			normalEmission ();
		}
			
	}







	float intialLightStrength;
	float tagetLightStrength = 0;
	float lightTime = 0.0f;
	float lightTimeLimitiation = 1f;
	bool hasBeenOff = true;

	void startLightShutDown(){
		lightTime = Time.time;
	}

	void turndownlights(){
		float l = GetComponent<Light> ().intensity;
		if (hasBeenOff) {
			lightTime = Time.time;
			hasBeenOff = false;
		}
		if (l > 0) {
			GetComponent<Light> ().intensity = calcLightStrength ();
		}
	}

	float calcLightStrength(){
		float f;
		f = Mathf.Lerp (intialLightStrength, tagetLightStrength, ((Time.time - lightTime) * lightTimeLimitiation) / intialLightStrength);
		if (f < 0) {
			f = 0;
		}
		return f;
	}

	float stratemissionrate;
	ParticleSystem mysystem;
	Material myPart;
	Color startTint;

	void startPart(){
		mysystem = transform.GetChild(0).GetComponent<ParticleSystem>();
		myPart = transform.GetChild(0).GetComponent<Renderer>().material;
		startTint = myPart.GetColor ("_TintColor");
	}



	void explode(){
		var emission = mysystem.emission;
		emission.rateOverTime = 1000f;
		ChangeTintColor (myPart.GetColor ("_TintColor") * 0.95f);
	}


	void normalEmission(){
		var emission = mysystem.emission;
		emission.rateOverTime = 20f;
	}




	void ChangeTintColor(Color newColor) {
		myPart.SetColor ("_TintColor", newColor);
	}

}
