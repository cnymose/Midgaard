using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour {
    public List<TerrainPiece> connectedTerrains;
    public Vector3 worldCenter;
	
    public void CalculateWorldPosition() {
        worldCenter = transform.GetComponent<Terrain>().terrainData.size / 2;
    }
}
