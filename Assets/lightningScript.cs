using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningScript : MonoBehaviour {
    public ParticleSystem lightningEmitters;
    private ParticleSystem player;
    private float time = 5f;
	
	
	// Update is called once per frame
	void Start () {
        player = lightningEmitters;
        StartCoroutine(emitLightning());
	}

   IEnumerator emitLightning()
    {
        while (true)
        {
            
            
            player.Play();
            
          
            yield return new WaitForSeconds(time );
            time = Random.Range(10, 20);
            player.Stop();
        }
        
       
        
    }
}
