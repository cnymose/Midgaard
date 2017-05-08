using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KennaDangerTrigger : MonoBehaviour
{

    bool triggered = false;
    bool activeGui = true;
    GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {

            triggered = true;
            GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().source.clip = GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().clips[6];
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
            GUI.Label(new Rect(Screen.width / 3.5f, Screen.height / 1.2f, 10, 10), "Watch out, danger is close..", guiStyle);
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
