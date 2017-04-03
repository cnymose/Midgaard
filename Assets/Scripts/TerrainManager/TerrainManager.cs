﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Midgaard
{

    public class TerrainManager : MonoBehaviour
    {


        private TerrainPiece currentTerrain;
        private PlayerMovement pm;
        private TerrainPiece[] allTerrains;
        public List<TerrainPiece> startTerrains;
        private bool checkingTerrains = true;
        private float timeBetweenChecks = 5;

        // Use this for initialization
        void Start()
        {
            allTerrains = FindObjectsOfType<TerrainPiece>();
            pm = FindObjectOfType<PlayerMovement>();

            for (int i = 0; i < allTerrains.Length; i++) {
                allTerrains[i].CalculateWorldPosition();
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
                if (currentTerrain != pm.currentTerrain)
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
                if (currentTerrain.connectedTerrains[i] != newTerrain) {
                    currentTerrain.connectedTerrains[i].gameObject.SetActive(false);
                }
            }

                    currentTerrain = newTerrain;
        }

        private void UpdateVisibleTerrain() {

            float lowestDist = Vector3.Distance(currentTerrain.connectedTerrains[0].worldCenter, pm.transform.position);
            TerrainPiece lowestDistancePiece = currentTerrain.connectedTerrains[0];

            for (int i = 1; i < currentTerrain.connectedTerrains.Count; i++) {
                float dist = Vector3.Distance(currentTerrain.connectedTerrains[i].worldCenter, pm.transform.position);
                if (dist < lowestDist) {
                    lowestDist = dist;
                    lowestDistancePiece = currentTerrain.connectedTerrains[i];
                }
            }

            if (!lowestDistancePiece.gameObject.activeInHierarchy) {
                for (int i = 0; i < currentTerrain.connectedTerrains.Count; i++) {
                    currentTerrain.connectedTerrains[i].gameObject.SetActive(false);
                }
                lowestDistancePiece.gameObject.SetActive(true);
            }

        }
    }
    }