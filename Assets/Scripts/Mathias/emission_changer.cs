using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emission_changer : MonoBehaviour {

	public float emission_power = 0.5f;

	public enum emission_type_
	{
		Constant,
		PingPong,
		valueBased
	};
		
	public emission_type_ emission_cur;

	public Color emission_color;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float emission = Mathf.PingPong((Time.time), 1.0f)* Mathf.PingPong((Time.time),1);


		Color finalColor = emission_color * Mathf.LinearToGammaSpace (emission) * 1;
		Change_Emision_color (finalColor);

		//DynamicGI.SetEmissive(GetComponent<Renderer>(), new Color(1,0,0,1));
	}

	void Change_Emision_color(Color newColor) {
		Renderer renderer = GetComponent<Renderer> ();
		Material mat = renderer.material;
		mat.SetColor ("_EmissionColor", newColor);
	}




}
