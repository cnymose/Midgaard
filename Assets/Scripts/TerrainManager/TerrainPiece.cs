using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour {
    public List<TerrainPiece> connectedTerrains;
    public Vector3 worldCenter;
    public GameObject coordinateCube;
    private GameObject self;
	
    public void CalculateWorldPosition() {
        
        coordinateCube = gameObject.transform.Find("CoordinateCube").gameObject;
        worldCenter = coordinateCube.transform.position;
        
    }
}
