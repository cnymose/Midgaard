using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbienceTransitionExit : MonoBehaviour {

    public List<AudioMixerSnapshot> Snapshots;
    public float transTime;


    public void OnTriggerExit(Collider other)
    {

        if (!other.CompareTag("Player")) return;

        foreach (var snapshot in Snapshots)
        {
            snapshot.TransitionTo(transTime);
        }

    }
}
