using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour {
    public List<TerrainPiece> connectedTerrains;
    public int temporalOrder;
    public Vector3 worldCenter;
    public GameObject coordinateCube;
    private GameObject self;
    public bool isLocked = false;
	
    public void CalculateWorldPosition() {
        
        coordinateCube = gameObject.transform.Find("CoordinateCube").gameObject;
        worldCenter = coordinateCube.transform.position;
        
    }
}
