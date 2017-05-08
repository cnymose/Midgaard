using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midgaard
{
	public class town_exit : MonoBehaviour {

		public bool talkedWithVrokr=false;
		bool hasPlayed = false;
		private DramaManager SM;
		private TerrainManager TM;
		AudioSource aud;

		// Use this for initialization
		void Start () {
			SM = GameObject.Find("Managers").GetComponent<DramaManager>();
			TM = GameObject.Find("Managers").GetComponent<TerrainManager>();
			aud = transform.GetComponent<AudioSource> ();
		}
		
		// Update is called once per frame
		void Update () {

			//make it work with terrain Maneger (change name space)

			//if (TM.nextArea >= 2) {
					if (SM.storySegments [3].mainEvent.interacted && !hasPlayed) {
						hasPlayed = true;
						aud.Play ();
					}
			//	}
		}
				
	}
}