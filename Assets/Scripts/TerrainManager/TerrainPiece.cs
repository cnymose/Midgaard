using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour {
    public List<TerrainPiece> connectedTerrains;
    public Vector3 worldCenter;
    public GameObject coordinateCube;
	
    public void CalculateWorldPosition() {
        worldCenter = coordinateCube.transform.position;
        
    }
}
