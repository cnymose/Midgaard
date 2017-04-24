using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbienceTransitionEnter : MonoBehaviour {

    public List<AudioMixerSnapshot> Snapshots;
    public float transTime;


    public void OnTriggerEnter(Collider other) {

        if (!other.CompareTag("Player")) return;

        foreach (var snapshot in Snapshots) {
            snapshot.TransitionTo(transTime);
        }

    }
	
}
