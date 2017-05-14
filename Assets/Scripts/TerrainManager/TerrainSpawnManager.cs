using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

    public class TerrainSpawnManager : MonoBehaviour
    {
        public int nextArea = 0;
        
        public List<GameObject> areas;
        private PlayerMovement pm;
        private GameObject player;
        public TerrainPiece currentPiece;
        private List<GameObject> allAreas; 
        private GameObject previousPiece;
        private GameObject[] exits = new GameObject[3];
        private GameObject previousExit;
        private bool calculateDistance = true;
			
	private bool[][] usedExits;
	private string[] namesOfAreas;
	string CEFUE;

        void Start()
        {
			usedExits = new bool[areas.Count+1][];
			namesOfAreas = new string[areas.Count+1];
			for (int i = 0; i < areas.Count+1; i++) {
			if (i < areas.Count) {	
				namesOfAreas [i] = areas [i].name;
			} else {
				namesOfAreas [i] = "PolyEnvironment_StartArea";
			}
			}
			for (int i = 0; i < usedExits.Length; i++) {
				usedExits [i] = new bool[]{true,true,true};
			}

            player = GameObject.Find("Player").gameObject;
            pm = player.GetComponent<PlayerMovement>();
            
           
            
            previousPiece = currentPiece.transform.gameObject;
            
            exits[0] = currentPiece.transform.FindChild("Exit " + 1).gameObject;
            exits[1] = currentPiece.transform.FindChild("Exit " + 2).gameObject;
            exits[2] = currentPiece.transform.FindChild("Exit " + 3).gameObject;


            StartCoroutine(areaCheck());

        }
		

        IEnumerator areaCheck()
        {
		Debug.Log (currentPiece.name);
            while (calculateDistance)
            {
              
                yield return new WaitForSeconds(5f);
                if (!currentPiece.Equals(pm.currentTerrain))
                {
				bool testing=false;
				for(int i = 0; i<namesOfAreas.Length;i++){
					if (pm.currentTerrain.name == namesOfAreas [i]) {
						testing = true;
					}
				}
				if (testing) {
					for (int i = 0; i < usedExits.Length; i++) {
						if (namesOfAreas [i].Equals (currentPiece.name)) {
							for (int j = 0; j < usedExits [i].Length; j++) {
								if (exits [j].name.Equals (CEFUE) && areas[nextArea].name == pm.currentTerrain.name) {
									usedExits [i] [j] = false;
									Debug.Log ("turn off " + exits [j].name + " " + namesOfAreas [i]);
								}
							}
						}
					}
				}
                    currentPiece = pm.currentTerrain;
                    previousPiece = currentPiece.transform.gameObject;
                    areas.Remove(currentPiece.gameObject);
                    
                    if(areas.Contains(currentPiece.gameObject))
                    nextArea++;
                
//                if (previousExit != null && !areas.Contains(currentPiece.gameObject))
//                    previousExit.transform.gameObject.SetActive(false);
                    //Debug.Log("Current Area " + nextArea);
                   // lockedPiece.Add(currentPiece);
					
                    exits[0] = currentPiece.transform.FindChild("Exit " + 1).gameObject;
                    exits[1] = currentPiece.transform.FindChild("Exit " + 2).gameObject;
                    exits[2] = currentPiece.transform.FindChild("Exit " + 3).gameObject;
					
					

               /*     foreach (GameObject obj in areas)
                    {
                        if (obj.Equals(currentPiece.gameObject))
                        {
                            areas.Remove(obj);
                        }
                    } */
                }

                distanceToExit();

            }
            yield return null;
        }
		
//	for (int i = 0; i < usedExits.Length; i++) {
//		for (int j = 0; j < usedExits[i].Length; j++){
//			if()
//			}
//	}

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
            for (int i = 0; i < exits.Length; i++)
            {
                float dist = Vector3.Distance(player.transform.position, exits[i].transform.position);

                if (dist < shortestDistance && exits[i].activeInHierarchy)
                {
                    shortestDistance = dist;
                    closestExit = exits[i];
                }

            }
           // Debug.Log("Closest Exit " + closestExit.transform.parent.name);
			CEFUE = closestExit.transform.name;
			spawnArea(closestExit);
			
        }


        public void spawnArea(GameObject exit)
	{
		//Debug.Log ("this is " + currentPiece.name);
		bool somethingisNotThere = false;

		for (int i = 0; i < usedExits.Length; i++) {
			for (int j = 0; j < usedExits [i].Length; j++) {

				if (namesOfAreas [i].Equals (currentPiece.name) && exits [j].name.Equals (CEFUE)) {
						somethingisNotThere = usedExits [i] [j];
				}

			}
		}
		if (!somethingisNotThere) {
			Debug.Log ("could not spawn at " + currentPiece.name + " " + CEFUE);
		}

		if (somethingisNotThere) {
			Debug.Log ("RASMUS!!! " + currentPiece.name + " " + CEFUE);
			var area = areas [nextArea];
			var rotation = area.transform.rotation;
			var temp = exit;
			area.transform.rotation = previousPiece.transform.rotation;
            
			if (exit.transform.name == "Exit 1") {
				area.transform.RotateAround (area.transform.position, area.transform.up, 270);
			}

			if (exit.transform.name == "Exit 3") {
				area.transform.RotateAround (area.transform.position, area.transform.up, 90);
			}

			var dir = exit.transform.position - area.transform.FindChild ("Enter").transform.position;
			area.transform.position += dir;
			area.SetActive (true);
			previousExit = exit;
			}
		}

    }
