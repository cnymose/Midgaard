using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spawn_event : MonoBehaviour
    {      

        // Use this for initialization
        void start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
			if (blob.name != "Shrine") {
			bool bum = raycastStart();
			}
        }

        public float distToSpawn = 25f;
        float hightToSpawn = 100f;
        public GameObject blob;
        public float angle;
        public float heightOfObject = 1f;



        public float maxHightDiff = 3f;

        GameObject lastPlaced;

       // public Terrain terrain;

        public bool raycastStart()
        {
          //  terrain = GetComponent<PlayerMovement>().currentTerrain.GetComponent<Terrain>();
            Vector3 FwH = new Vector3(transform.forward.x, 0, transform.forward.z);
            Vector3 normFwH = Quaternion.Euler(0, Random.Range(-(angle / 2), (angle / 2)), 0) * Vector3.Normalize(FwH);
            Vector3 starHere = normFwH * distToSpawn + new Vector3(0, hightToSpawn, 0) + transform.position;

            RaycastHit hit;

            if (Physics.Raycast(starHere, -Vector3.up, out hit))
            {
                Vector3 centerPoint = new Vector3(hit.point.x, hit.point.y + (heightOfObject / 2), hit.point.z);
                if (hit.transform.gameObject.tag == "Spawn Area")
                {
				
                    Destroy(lastPlaced);
                    GameObject box = (GameObject)Instantiate(blob, centerPoint, transform.rotation);
                    lastPlaced = box;
                    bool shouldDestroy = false;
                    for (int i = 0; i < box.transform.childCount; i++)
                    {
                        RaycastHit childHit;
                        box.transform.GetChild(i).transform.GetChild(0).gameObject.layer = 18;

                        int layerMask = 1 << 18;
                        layerMask = ~layerMask;

                        if (Physics.Raycast(new Vector3(0, 20f, 0) + box.transform.GetChild(i).transform.position, -Vector3.up, out childHit, Mathf.Infinity, layerMask))
                        {
                        
                        if (childHit.transform.gameObject.tag == "Spawn Area" && Vector3.Angle(childHit.normal, blob.transform.up) < 30)
                            {
                            
                                box.transform.GetChild(i).transform.position = childHit.point;
                                box.transform.GetChild(i).transform.rotation =
                                    Quaternion.FromToRotation(blob.transform.forward, new Vector3(childHit.point.x - transform.position.x, 0, childHit.point.z - transform.position.z)) *
                                    blob.transform.GetChild(i).rotation *
                                    Quaternion.FromToRotation(blob.transform.up, childHit.normal);
                            }
                            else
                                shouldDestroy = true;
                        }
                    
                }

                    float hightMax = box.transform.GetChild(0).transform.position.y;
                    float hightMin = hightMax;
                    for (int i = 0; i < box.transform.childCount; i++)
                    {

                        if (box.transform.GetChild(i).transform.position.y > hightMax)
                            hightMax = box.transform.GetChild(i).transform.position.y;
                        if (box.transform.GetChild(i).transform.position.y < hightMin)
                            hightMin = box.transform.GetChild(i).transform.position.y;
                    }
                    if (Mathf.Abs(hightMax - hightMin) > maxHightDiff)
                    {
                        shouldDestroy = true;
                    }

                    if (shouldDestroy == true)
                    {
                        Destroy(lastPlaced);
                        return false;
                    }
                    return true;
                }
                else
                {
             
                    Destroy(lastPlaced);
                    return false;
                }
            }
            Destroy(lastPlaced);
            return false;
        }

    }

