using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Clip01());
        StartCoroutine(Clip02());
        StartCoroutine(Clip03());
        StartCoroutine(Clip04());
        StartCoroutine(Clip05());
        StartCoroutine(Clip06());
    }

    IEnumerator Clip01() {

        yield return new WaitForSeconds(3.0f);
        GameObject.Find("TrollFootsteps01").gameObject.GetComponent<AudioSource>().Play();

    }

    IEnumerator Clip02()
    {

        yield return new WaitForSeconds(4.0f);
        GameObject.Find("TrollSound01").gameObject.GetComponent<AudioSource>().Play();

    }

    IEnumerator Clip03()
    {

        yield return new WaitForSeconds(15.0f);
        GameObject.Find("TrollSound02").gameObject.GetComponent<AudioSource>().Play();

    }

    IEnumerator Clip04()
    {

        yield return new WaitForSeconds(18.0f);
        GameObject.Find("TrollFootsteps01").gameObject.GetComponent<AudioSource>().Play();

    }

    IEnumerator Clip05()
    {

        yield return new WaitForSeconds(25.0f);
        GameObject.Find("TrollSound03").gameObject.GetComponent<AudioSource>().Play();

    }

    IEnumerator Clip06()
    {

        yield return new WaitForSeconds(35.0f);
        GameObject.Find("TrollFootsteps01").gameObject.GetComponent<AudioSource>().Play();

    }

}
