using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TerrainSpawnManager : MonoBehaviour
{
    public int currentArea = 0;
    public TerrainPiece[] spawnPositions;
    public GameObject[] areas;
    private PlayerMovement pm;
    private bool calculateDistance = true;

    public void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i].CalculateWorldPosition();

            if (!spawnPositions.Contains(spawnPositions[i]))
            {
                spawnPositions[i].gameObject.SetActive(false);
            }
        }
        StartCoroutine(areaCheck());
    }

    public void Update()
    {

    }

    IEnumerator areaCheck()
    {
        while (calculateDistance)
        {
            yield return new WaitForSeconds(5f);
        

        }
    }

    public void spawnArea()
    {

    }


}
