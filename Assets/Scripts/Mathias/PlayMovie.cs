using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	void Start () {
		myMovie.Play();
		aud.Play();
	}

	// Update is called once per frame
	void Update () {
		
		if (!myMovie.isPlaying) {
			if (myMovie.name == "Intro") {
				Application.LoadLevel (SceneName);
			}
			Debug.Log ("slut");
		}
	}


	public MovieTexture myMovie;
	public AudioSource aud;

	private IEnumerator Wait(float duration)
	{
		yield return new WaitForSeconds(duration);
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myMovie);

	}




}
