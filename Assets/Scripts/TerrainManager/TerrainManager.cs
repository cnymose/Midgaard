using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Midgaard
{

    public class TerrainManager : MonoBehaviour
    {


        public TerrainPiece currentTerrain;
        private PlayerMovement pm;
        public TerrainPiece[] allTerrains;
        public List<TerrainPiece> startTerrains;
        private bool checkingTerrains = true;
        private float timeBetweenChecks = 5;
        private Vector3 test;
       
        // Use this for initialization
        void Start()
        {
            allTerrains = FindObjectsOfType<TerrainPiece>();
            pm = FindObjectOfType<PlayerMovement>();

            for (int i = 0; i < allTerrains.Length; i++)
            {
                allTerrains[i].CalculateWorldPosition();
                test = allTerrains[i].worldCenter;
                Debug.Log("x:" + test.x + "y:" + test.y + "z:" + test.z);
                if (!startTerrains.Contains(allTerrains[i]))
                {
                    allTerrains[i].gameObject.SetActive(false);
                }
            }
            
            currentTerrain = startTerrains[0];
            StartCoroutine(UpdateTerrain());
        }
        


        private IEnumerator UpdateTerrain()
        {
            
            while (checkingTerrains)
            {
                yield return new WaitForSeconds(timeBetweenChecks);
                if (!currentTerrain.Equals(pm.currentTerrain))
                {
                    SwitchTerrain(pm.currentTerrain);
                }
                UpdateVisibleTerrain();
                
            }
            yield break;
        }

        private void SwitchTerrain(TerrainPiece newTerrain)
        {

            for (int i = 0; i < currentTerrain.connectedTerrains.Count; i++) {
                if (!currentTerrain.connectedTerrains[i].Equals(newTerrain)) {
                    if(!startTerrains.Contains(currentTerrain.connectedTerrains[i]))
                    currentTerrain.connectedTerrains[i].gameObject.SetActive(false);
                }
            }
            // Setting current Terrain to the new terrain which the player has recently collided with
            currentTerrain = newTerrain;
          
            if (!startTerrains.Contains(currentTerrain))
            {
                startTerrains.Add(currentTerrain); // Adding new terrain to start terrain array making it always visible
                RemoveFromSearch(currentTerrain);
            }
        }
        /*
                private void RemoveFromSearch(TerrainPiece newTerrain)
                {
                    for(int i = 0; i < allTerrains.Length; i++)
                    {
                        for (int j = 0; j < allTerrains[i].connectedTerrains.Count; j ++)
                        {
                            for (int k = 0; k < startTerrains.Count; k++)
                            {
                                if (allTerrains[i].connectedTerrains[j].GetComponent<Terrain>().terrainData.Equals(startTerrains[k].GetComponent<Terrain>().terrainData))
                                {

                                    if (startTerrains[k].transform.parent.Equals(newTerrain.transform.parent))
                                   {

                                        allTerrains[i].connectedTerrains.Remove(allTerrains[i].connectedTerrains[j]);
                                    }

                                }
                             }
                         }
                    }
                }
                */

        private void RemoveFromSearch(TerrainPiece newTerrain)
        {
            for (int i = 0; i < allTerrains.Length; i++)
            {
                for (int j = 0; j < allTerrains[i].connectedTerrains.Count; j++)
                {
                    for (int k = 0; k < startTerrains.Count; k++)
                    {
                       

                            if (startTerrains[k].transform.Equals(newTerrain.transform))
                            {

                                allTerrains[i].connectedTerrains.Remove(allTerrains[i].connectedTerrains[j]);
                            }

                        
                    }
                }
            }
        }
        private void UpdateVisibleTerrain() {

            float lowestDist = Vector3.Distance(currentTerrain.connectedTerrains[0].worldCenter, pm.transform.position);
            TerrainPiece lowestDistancePiece = currentTerrain.connectedTerrains[0];

            for (int i = 1; i < currentTerrain.connectedTerrains.Count; i++)
            {
              
                    float dist = Vector3.Distance(currentTerrain.connectedTerrains[i].worldCenter, pm.transform.position);
                    if (dist < lowestDist)
                    {
                        lowestDist = dist;
                        lowestDistancePiece = currentTerrain.connectedTerrains[i];
                    }
                
            }
            if (!lowestDistancePiece.gameObject.activeInHierarchy) {
               for (int i = 0; i < currentTerrain.connectedTerrains.Count; i++) {
                  if(!startTerrains.Contains(currentTerrain.connectedTerrains[i]))
                  currentTerrain.connectedTerrains[i].gameObject.SetActive(false);
                }
                lowestDistancePiece.gameObject.SetActive(true);
           }

        }
    }
    }
