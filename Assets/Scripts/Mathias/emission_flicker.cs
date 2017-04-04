using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emission_flicker : MonoBehaviour {

	public enum WaveForm {sin, tri, sqr, saw, inv, noise};
	public WaveForm waveform = WaveForm.sin;   

	public float baseStart = 0.0f; 	// start 
	public float amplitude = 1.0f; 	// amplitude of the wave
	public float phase = 0.0f; 		// start point inside on wave cycle
	public float frequency = 0.5f; 	// cycle frequency per second

	public Color emissionColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color finalColor = emissionColor * Mathf.LinearToGammaSpace (Wave());
		ChangeEmisionColor (finalColor);

	}

	float Wave () {
		float x = (Time.time + phase) * frequency;
		float y = 1;
		x = x - Mathf.Floor(x); // normalized value (0..1)

		switch (waveform) {
		case WaveForm.sin:
			y = Mathf.Sin(x * 2 * Mathf.PI);
			break;
		case WaveForm.tri:
			if (x < 0.5f)
				y = 4.0f * x - 1.0f;
			else
				y = -4.0f * x + 3.0f;  
			break;
		case WaveForm.sqr:
			if (x < 0.5f)
				y = 1.0f;
			else
				y = 0.0f;  
			break;
		case WaveForm.saw:
			y = x;
			break;
		case WaveForm.inv:
			y = 1.0f - x;
			break;
		case WaveForm.noise:
			y = 1f - (Random.value * 2);
			break;
		}
		if (y < 0)
			y = Mathf.Abs (y);
		return (y * amplitude) + baseStart;
	}

	void ChangeEmisionColor(Color newColor) {
		Renderer renderer = GetComponent<Renderer> ();
		Material mat = renderer.material;
		mat.SetColor ("_EmissionColor", newColor);
	}

}
