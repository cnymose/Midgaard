using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningScript : MonoBehaviour {
    public ParticleSystem[] lightningEmitters;
    public bool emitLight = true;
    private ParticleSystem player;
    private float time = 15f;
	
	
	// Update is called once per frame
	void Start () {
       
        StartCoroutine(emitLightning());
	}

   IEnumerator emitLightning()
    {
        while (emitLight)
        {

            player = lightningEmitters[Random.Range(0, lightningEmitters.Length)];
            player.Play();          
          
            yield return new WaitForSeconds(time);
            time = Random.Range(15, 25);
            player.Stop();
        }
        
       
        
    }
}
