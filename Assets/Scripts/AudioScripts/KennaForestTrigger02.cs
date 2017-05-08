﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennaForestTrigger02 : MonoBehaviour {

    bool triggered = false;
    bool activeGui = true;
    private GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {

            triggered = true;
            GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().source.clip = GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().clips[5];
            GameObject.Find("kenna").gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(guiTime());
        }
    }

    void OnGUI()
    {
        if (triggered && activeGui)
        {
            //Debug.Log("You're goddamn right");
            guiStyle.fontSize = 35;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 4.5f, Screen.height / 1.3f, 10, 10), "“Nornabaugur (elfring). Where the ancient elves used to dance.. \n The myths say it is a portal to the realm of the elves. \n You should not step into the ring now. Time is nigh and the elves are not kind to outsiders”", guiStyle);
        }
    }

    IEnumerator guiTime()
    {
        var source = GameObject.Find("kenna").gameObject.GetComponent<AudioSource>();
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(1.0f);
        }
        activeGui = false;
    }
}
