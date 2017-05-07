﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TerrainSpawnManager : MonoBehaviour
{
    public int currentArea = 0;
    public List<TerrainPiece> spawnableArea;
    public List<TerrainPiece> lockedPiece;
    public List<GameObject> areas;
    private PlayerMovement pm;
    private GameObject player;
    private TerrainPiece currentPiece;
    private GameObject previousPiece;
    private GameObject[] exits = new GameObject[3];
    private bool calculateDistance = true;

    public void Start()
    {
        player = GameObject.Find("Player").gameObject;
        pm = player.GetComponent<PlayerMovement>();
        lockedPiece.Add(pm.currentTerrain);
        currentPiece = pm.currentTerrain;
        previousPiece = currentPiece.transform.gameObject;

        exits[0] = currentPiece.transform.parent.FindChild("Exit " + 1).gameObject;
        exits[1] = currentPiece.transform.parent.FindChild("Exit " + 2).gameObject;
        exits[3] = currentPiece.transform.parent.FindChild("Exit " + 3).gameObject;

        StartCoroutine(areaCheck());

    }

  IEnumerator areaCheck()
    {
        while (calculateDistance)
        {
            yield return new WaitForSeconds(5f);
            if (!currentPiece.Equals(pm.currentTerrain))
            {
               
                currentPiece = pm.currentTerrain;
                previousPiece = currentPiece.transform.gameObject;
                currentArea++;
                lockedPiece.Add(currentPiece);

                exits[0] = currentPiece.transform.parent.FindChild("Exit " + 1).gameObject;
                exits[1] = currentPiece.transform.parent.FindChild("Exit " + 2).gameObject;
                exits[3] = currentPiece.transform.parent.FindChild("Exit " + 3).gameObject;

                foreach (GameObject obj in areas)
                {
                    if (obj.Equals(currentPiece.gameObject))
                    {
                        areas.Remove(obj);
                    }
                }
            }

            distanceToExit();

        }
    }
    public void distanceToExit()
    {
        bool iterate = true;
        float shortestDistance = 0;
        GameObject closestExit = null;
        int j = 0;

        while (iterate)
        {
            if (exits[j] != null)
            {
                shortestDistance = Vector3.Distance(player.transform.position, exits[j].transform.position);
                closestExit = exits[j];
                iterate = false;
            }
            else
            {
               j++;
            }
            
        }
        for(int i = 0; i < exits.Length; i++)
        {
            float dist = Vector3.Distance(player.transform.position, exits[i].transform.position);

            if(dist < shortestDistance)
            {
                shortestDistance = dist;
                closestExit = exits[i];
            }

        }
        spawnArea(closestExit);
        
    }


    public void spawnArea(GameObject exit)
    {
        var area = areas[currentArea];
        var rotation = area.transform.rotation;
        var temp = exit;
        area.transform.rotation = previousPiece.transform.rotation;

        if (exit.transform.name == "Exit 1")
        {
            area.transform.RotateAround(area.transform.position, area.transform.up, 270);
        }
        
        if (exit.transform.name == "Exit 3")
        {
            area.transform.RotateAround(area.transform.position, area.transform.up, 90);
        }

        var dir = exit.transform.position - area.transform.FindChild("Enter").transform.position;
        area.transform.position += dir; 


    }


}
