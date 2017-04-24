using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathblockScript : MonoBehaviour {
    public TerrainPiece terrain;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!terrain.transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(true);
        }
        else
            transform.gameObject.SetActive(false);
	}
}
