using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour {
    public List<TerrainPiece> connectedTerrains;
    public Vector3 worldCenter;
	// Use this for initialization
	void Start () {
        worldCenter = transform.position + GetComponent<Terrain>().terrainData.size / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
