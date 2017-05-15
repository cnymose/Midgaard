using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalPresence : MonoBehaviour {
    bool triggered = false;
    GUIStyle guiStyle = new GUIStyle();
    bool activeGui = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        if (!triggered)
        {
            triggered = true;
            GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().source.clip = GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().clips[2];
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
            GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 1.2f, 500, 500), "I can feel a magical presence nearby.. ", guiStyle);
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
