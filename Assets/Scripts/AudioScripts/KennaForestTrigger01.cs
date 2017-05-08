using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennaForestTrigger01 : MonoBehaviour {

    bool triggered = false;
    private GUIStyle guiStyle = new GUIStyle();
    bool activeGui = true;

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
            GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().source.clip = GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().clips[4];
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
            GUI.Label(new Rect(Screen.width /4.5f, Screen.height / 1.2f, 10, 10), "You must hurry.. Svalinn is an artifact of the old gods. \n we will need it if we are to ever restore the world as it once was..", guiStyle);
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
