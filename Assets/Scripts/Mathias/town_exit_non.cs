﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard { 

public class town_exit_non : MonoBehaviour {

    public bool talkedWithVrokr = false;
    bool hasPlayed = false;
    private DramaManager SM;
    private TerrainManager TM;
    bool triggered = false;
    private GUIStyle guiStyle = new GUIStyle();
    bool activeGui = true;


    // Use this for initialization
    void Start()
    {
        SM = GameObject.Find("Managers").GetComponent<DramaManager>();
        TM = GameObject.Find("Managers").GetComponent<TerrainManager>();

    }

    // Update is called once per frame
    void Update()
    {

        //make it work with terrain Maneger (change name space)

        //if (TM.nextArea >= 2) {

        //	}
    }


        private void OnTriggerEnter(Collider other)
        {

            var vrokr = GameObject.Find("Vrokr").gameObject.GetComponent<vroklNPC>().interacted;

            if (!vrokr && !triggered)
            {
                triggered = true;


                GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().source.clip = GameObject.Find("kenna").gameObject.GetComponent<KennaTalk>().clips[1];
                GameObject.Find("kenna").gameObject.GetComponent<AudioSource>().Play();

                StartCoroutine(guiTime());
            }
        }

        void OnGUI()
    {
        if (triggered && activeGui)
        {

            guiStyle.fontSize = 35;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 1.2f, 500, 500), "Did you find Vrokr in the town? He will aid you in your search for Svalinn", guiStyle);
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
        //  &&
    }
}
