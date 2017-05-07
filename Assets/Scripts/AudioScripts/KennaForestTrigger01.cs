using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennaForestTrigger01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("KennaVoice01").gameObject.GetComponent<AudioSource>().Play();
        transform.gameObject.SetActive(false);
    }
}
