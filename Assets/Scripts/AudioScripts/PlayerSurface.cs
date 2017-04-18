using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurface : MonoBehaviour
{

    //findTextureTerrain surface;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        soundState();

    }

    public void soundState()
    {
        var soundScript = GetComponent<SoundState>();

        switch (player.GetComponent<findTextureTerrain>().surfaceIndex)
        {

            case 0:
                soundScript.surface = SoundState.SurfaceState.Grass;
                break;

            case 1:
                soundScript.surface = SoundState.SurfaceState.Dirt;
                break;


        }
    }
}
